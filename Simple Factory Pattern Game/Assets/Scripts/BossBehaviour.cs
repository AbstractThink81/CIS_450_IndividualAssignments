/*
 * Ian Connors
 * BossBehaviour.cs
 * CIS 450 Assignment 5 - Simple Factory Pattern
 * Controls the movement of the boss character
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
	private Attack[] attacks = new Attack[2];
	private int attackPhase;
	public int canShoot;
	AudioSource audioSource;
	AudioClip audioClip;

	private void Start()
	{
		attackPhase = 0;
		attacks[0] = gameObject.AddComponent<BossAttack0>();
		attacks[1] = gameObject.AddComponent<BossAttack1>();
		StartCoroutine(BossSequence());
		canShoot = 0;
		audioSource = gameObject.AddComponent<AudioSource>();

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("PlayerBullet"))
			GameManager.BossHurt();
	}
	public void DeathAnimation()
	{
		List<GameObject> bullets = new List<GameObject>();
		bullets.AddRange(GameObject.FindGameObjectsWithTag("PlayerBullet"));
		bullets.AddRange(GameObject.FindGameObjectsWithTag("BossBullet"));
		foreach (GameObject go in bullets)
		{
			Destroy(go);
		}
		StopAllCoroutines();
		StartCoroutine(BossDeath());
	}
	private void FixedUpdate()
	{
		if (canShoot < 60)
		{
			canShoot++;
		}
	}
	private void Update()
	{
		if (canShoot < 60)
		{
			foreach (GameObject go in GameObject.FindGameObjectsWithTag("BossBullet"))
				Destroy(go);
		}
	}
	private IEnumerator BossDeath()
	{
		audioClip = (AudioClip)Resources.Load("Sounds/DEFEATED");
		audioSource.PlayOneShot(audioClip);
		for (float f = 1; f > 0; f -= 0.01f)
		{
			yield return new WaitForSeconds(0.01f);
			GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, f);
		}
		yield return new WaitForSeconds(1.5f);
		GameManager.ShowEndMenu("Win");
	}
	private IEnumerator BossSequence()
	{
		yield return new WaitForSeconds(2f);
		GameManager.StartMusic();
		while (attackPhase == 0)
		{
			transform.position = (new Vector2(Random.Range(-5, 2), Random.Range(1.5f, 3)));
			yield return new WaitForSeconds(0.5f);
			attacks[0].StartAttack(transform.position);
			yield return new WaitForSeconds(0.1f);
			attacks[0].StartAttack(transform.position);
			yield return new WaitForSeconds(0.1f);
			attacks[0].StartAttack(transform.position);
			yield return new WaitForSeconds(0.1f);
			attacks[0].StartAttack(transform.position);

			transform.position = (new Vector2(Random.Range(-5, 2), Random.Range(1.5f, 3)));
			yield return new WaitForSeconds(0.5f);
			yield return new WaitForSeconds(0.5f);
			attacks[0].StartAttack(transform.position);
			yield return new WaitForSeconds(0.1f);
			attacks[0].StartAttack(transform.position);
			yield return new WaitForSeconds(0.1f);
			attacks[0].StartAttack(transform.position);
			yield return new WaitForSeconds(0.1f);
			attacks[0].StartAttack(transform.position);


			yield return new WaitForSeconds(1f);
			for (int j = 0; j < 3; j++)
			{

				transform.position = (new Vector2(Random.Range(-5, 2), Random.Range(1.5f, 3)));
				yield return new WaitForSeconds(0.5f);
				for (int i = 1; i < 20; i++)
				{
					attacks[1].StartAttack(new Vector2(transform.position.x - 3, transform.position.y));
					attacks[1].StartAttack(new Vector2(transform.position.x + 3, transform.position.y));
					yield return new WaitForSeconds(0.03f);
					attacks[1].StartAttack(new Vector2(transform.position.x - 3, transform.position.y));
					attacks[1].StartAttack(new Vector2(transform.position.x + 3, transform.position.y));
					yield return new WaitForSeconds(0.03f);
					attacks[1].StartAttack(new Vector2(transform.position.x + 2 * Mathf.Sin(i), transform.position.y));
					yield return new WaitForSeconds(0.02f);
				}
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
}
