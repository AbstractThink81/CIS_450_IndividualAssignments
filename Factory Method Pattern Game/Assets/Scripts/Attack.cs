/*
 * Ian Connors
 * Attack.cs
 * CIS 450 Assignment 6 - Factory Method Pattern
 * Abstract class for all of the attacks in the game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
	public enum BulletBehaviours
	{
		None,
		Seeking,
		Directed
	};
	public enum BulletTypes
	{
		Ball,
		Spade,
		Club,
		Clump,
		Heart,
		Diamond
	};
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
	public void StartAttack(Vector2 userPosition)
	{
		StartCoroutine(SpawnBullets(userPosition));
	}
	public abstract IEnumerator SpawnBullets(Vector2 userPosition);

	public void NewBullet(BulletTypes bulletType, Vector2 position, Quaternion rotation, int force, BulletBehaviours bulletBehaviour)
	{
		if (position.x >= -6 && position.x <= 3)
		{
			GameObject bullet = Instantiate(bulletPrefabs[(int)bulletType], position, rotation);
			Vector2 t = bullet.transform.up;
			bullet.GetComponent<Rigidbody2D>().AddForce(t * force, ForceMode2D.Impulse);


			if (bulletBehaviour == BulletBehaviours.Seeking)
			{
				bullet.AddComponent<SeekingBullet>();
				bullet.GetComponent<SeekingBullet>().seekingTarget = GameObject.FindGameObjectWithTag("Boss");
			}
			else if (bulletBehaviour == BulletBehaviours.Directed)
			{
				bullet.AddComponent<DirectedBullet>();
			}
			else
			{
				//bullet.AddComponent<StandardBullet>();
			}
		}
	}
	public void NewBullet(BulletTypes bulletType, Vector2 position, Quaternion rotation, int force, BulletBehaviours bulletBehaviour, Vector2 position2)
	{
		if (position.x >= -6 && position.x <= 3)
		{
			GameObject bullet = Instantiate(bulletPrefabs[(int)bulletType], position, rotation);
			Vector2 t = bullet.transform.up;
			bullet.GetComponent<Rigidbody2D>().AddForce(t * force, ForceMode2D.Impulse);


			if (bulletBehaviour == BulletBehaviours.Seeking)
			{
				bullet.AddComponent<SeekingBullet>();
				bullet.GetComponent<SeekingBullet>().seekingTarget = GameObject.FindGameObjectWithTag("Boss");
			}
			else if (bulletBehaviour == BulletBehaviours.Directed)
			{
				bullet.AddComponent<DirectedBullet>();
				bullet.GetComponent<DirectedBullet>().targetPosition = position2;
				bullet.GetComponent<DirectedBullet>().attack = (BossAttack3)this;
			}
			else
			{
				bullet.AddComponent<StandardBullet>();
			}
		}
	}
}
