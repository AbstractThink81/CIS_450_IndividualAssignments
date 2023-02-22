/*
 * Ian Connors
 * Attack.cs
 * CIS 450 Assignment 5 - Simple Factory Pattern
 * Abstract class for all of the attacks in the game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
	protected AudioSource audioSource;
	protected AudioClip audioClip;
	private GameObject[] bulletPrefabs = new GameObject[6];

	private void Awake()
	{
		bulletPrefabs[0] = (GameObject)Resources.Load("Bullets/bulletBall");
		bulletPrefabs[1] = (GameObject)Resources.Load("Bullets/bulletSpade");
		bulletPrefabs[2] = (GameObject)Resources.Load("Bullets/bulletClub");
		bulletPrefabs[3] = (GameObject)Resources.Load("Bullets/bulletClump");
		bulletPrefabs[4] = (GameObject)Resources.Load("Bullets/bulletHeart");
		bulletPrefabs[5] = (GameObject)Resources.Load("Bullets/bulletDiamond");

		audioSource = gameObject.AddComponent<AudioSource>();
	}
	public void StartAttack(Vector2 userPosition, bool focus)
	{
		StartCoroutine(SpawnBullets(userPosition, focus));
	}
	public void StartAttack(Vector2 userPosition)
	{
		StartCoroutine(SpawnBullets(userPosition, false));
	}
	public abstract IEnumerator SpawnBullets(Vector2 userPosition, bool focus);

	public void NewBullet(int bulletPrefabNumber, Vector2 position, Quaternion rotation, int force)
	{
		if (position.x > -6 && position.x < 3)
		{
			GameObject bullet = Instantiate(bulletPrefabs[bulletPrefabNumber], position, rotation);
			Vector2 t = bullet.transform.up;
			bullet.GetComponent<Rigidbody2D>().AddForce(t * force, ForceMode2D.Impulse);
		}
	}
}
