/*
 * Ian Connors
 * BossBehaviour.cs
 * CIS 450 Assignment 6 - Factory Method Pattern
 * Controls the movement of the boss character
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
	private Attack[] attacks = new Attack[4];
	public int attackPhase;
	public int canShoot;
	AudioSource audioSource;
	AudioClip audioClip;

	private void Start()
	{
		attackPhase = 0;
		attacks[0] = gameObject.AddComponent<BossAttack0>();
		attacks[1] = gameObject.AddComponent<BossAttack1>();
		attacks[2] = gameObject.AddComponent<BossAttack2>();
		attacks[3] = gameObject.AddComponent<BossAttack3>();
		canShoot = 0;
		audioSource = gameObject.AddComponent<AudioSource>();
		StartCoroutine(WaitStart());

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
	private IEnumerator WaitStart()
	{
		yield return new WaitForSeconds(1.5f);
		StartCoroutine(BossSequence(0));

	}
	public void NextAttackPhase(int phase)
	{
		StopAllCoroutines();
		List<GameObject> bullets = new List<GameObject>();
		bullets.AddRange(GameObject.FindGameObjectsWithTag("PlayerBullet"));
		bullets.AddRange(GameObject.FindGameObjectsWithTag("BossBullet"));
		foreach (GameObject go in bullets)
		{
			Destroy(go);
		}
		audioClip = (AudioClip)Resources.Load("Sounds/SPELLCARD");
		audioSource.PlayOneShot(audioClip);
		transform.position = new Vector2(-1.5f, 10f);
		attackPhase = phase;
		StartCoroutine(BossSequence(phase));
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
	private IEnumerator ShootTinyBullets()
	{
		for (int i = 1; i < 8; i++)
		{
			yield return new WaitForSeconds(0.1f);
			attacks[1].StartAttack(new Vector2(transform.position.x + 1, transform.position.y));
			attacks[1].StartAttack(new Vector2(transform.position.x - 1, transform.position.y));

		}
	}
	private IEnumerator StartAnnoyingExplodingBullets()
	{
		yield return new WaitForSeconds(4.3f);
		while (true)
		{
			yield return new WaitForSeconds(4.3f);
			attacks[3].StartAttack(transform.position);
		}
	}
	private IEnumerator BossSequence(int phase)
	{
		switch (phase)
		{
			case 0:
				yield return new WaitForSeconds(2f);
				transform.position = new Vector2(-1.5f, 3.5f);
				GameManager.StartMusic();
				while (true)
				{
					transform.position = (new Vector2(Random.Range(-5, 2), Random.Range(1.5f, 3)));
					yield return new WaitForSeconds(0.5f / Mathf.Pow(((int)GameManager.GetDifficulty() + 1), 0.5f));
					attacks[0].StartAttack(transform.position);
					yield return new WaitForSeconds(0.1f);
					attacks[0].StartAttack(transform.position);
					yield return new WaitForSeconds(0.1f);
					attacks[0].StartAttack(transform.position);
					yield return new WaitForSeconds(0.1f);
					attacks[0].StartAttack(transform.position);

					transform.position = (new Vector2(Random.Range(-5, 2), Random.Range(1.5f, 3)));
					yield return new WaitForSeconds(0.5f / Mathf.Pow(((int)GameManager.GetDifficulty() + 1), 0.5f));
					yield return new WaitForSeconds(0.5f / Mathf.Pow(((int)GameManager.GetDifficulty() + 1), 0.5f));
					attacks[0].StartAttack(transform.position);
					yield return new WaitForSeconds(0.1f);
					attacks[0].StartAttack(transform.position);
					yield return new WaitForSeconds(0.1f);
					attacks[0].StartAttack(transform.position);
					yield return new WaitForSeconds(0.1f);
					attacks[0].StartAttack(transform.position);


					yield return new WaitForSeconds(1f / Mathf.Pow(((int)GameManager.GetDifficulty() + 1), 0.8f));
					for (int j = 0; j < 3; j++)
					{

						transform.position = (new Vector2(Random.Range(-5, 2), Random.Range(1.5f, 3)));
						yield return new WaitForSeconds(0.5f / Mathf.Pow(((int)GameManager.GetDifficulty() + 1), 0.5f));
						for (int i = 1; i < 20; i++)
						{
							if (GameManager.GetDifficulty() == GameManager.LevelDifficulty.Hard || GameManager.GetDifficulty() == GameManager.LevelDifficulty.Lunatic)
							{
								attacks[1].StartAttack(new Vector2(transform.position.x + 2 * Mathf.Cos(i), transform.position.y));
							}
							attacks[1].StartAttack(new Vector2(transform.position.x - 3, transform.position.y));
							attacks[1].StartAttack(new Vector2(transform.position.x + 3, transform.position.y));
							yield return new WaitForSeconds(0.03f);
							if (GameManager.GetDifficulty() == GameManager.LevelDifficulty.Lunatic)
							{
								attacks[1].StartAttack(new Vector2(transform.position.x + 2 * Mathf.Tan(i), transform.position.y));
							}
							attacks[1].StartAttack(new Vector2(transform.position.x - 3, transform.position.y));
							attacks[1].StartAttack(new Vector2(transform.position.x + 3, transform.position.y));
							yield return new WaitForSeconds(0.03f);
							attacks[1].StartAttack(new Vector2(transform.position.x + 2 * Mathf.Sin(i), transform.position.y));
							
							yield return new WaitForSeconds(0.02f);
						}
						yield return new WaitForSeconds(0.1f);
					}
				}
			case 1:
				yield return new WaitForSeconds(2f);
				transform.position = new Vector2(-1.5f, 3.5f);
				StartCoroutine(StartAnnoyingExplodingBullets());
				while (true)
				{
					for (int j = 1; j < 3; j++)
					{
						for (int i = 1; i < 8; i++)
						{
							attacks[2].StartAttack(transform.position);
							yield return new WaitForSeconds(0.5f / Mathf.Pow(((int)GameManager.GetDifficulty() + 1), 0.5f));
						}
						transform.position = (new Vector2(Random.Range(-5, 2), Random.Range(1.5f, 3)));
						//StartCoroutine(ShootTinyBullets());
					}
				}
			case 2:
				yield return new WaitForSeconds(2f);
				transform.position = new Vector2(-1.5f, 3.5f);
				while (true)
				{
					for (float f = 1f; f > 0.05f; f -= 0.01f)
					{
						transform.position = (new Vector2(Random.Range(-5, 2), Random.Range(1.5f, 3)));
						yield return new WaitForSeconds(f / Mathf.Pow(((int)GameManager.GetDifficulty() + 1), 0.5f));
						attacks[0].StartAttack(transform.position);
						yield return new WaitForSeconds(f/5);
						attacks[0].StartAttack(transform.position);
						yield return new WaitForSeconds(f/5);
						attacks[0].StartAttack(transform.position);
						yield return new WaitForSeconds(f/5);
						attacks[0].StartAttack(transform.position);
					}
					while (true)
					{
						transform.position = (new Vector2(Random.Range(-5, 2), Random.Range(1.5f, 3)));
						yield return new WaitForSeconds(0.05f);
						attacks[0].StartAttack(transform.position);
						yield return new WaitForSeconds(0.05f / 5);
						attacks[0].StartAttack(transform.position);
						yield return new WaitForSeconds(0.05f / 5);
						attacks[0].StartAttack(transform.position);
						yield return new WaitForSeconds(0.05f / 5);
						attacks[0].StartAttack(transform.position);
					}


				}
		};
	}
}
