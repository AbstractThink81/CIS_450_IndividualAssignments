/*
 * Ian Connors
 * BossAttack2.cs
 * CIS 450 Assignment 6 - Factory Method Pattern
 * One of the attacks for the boss
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack2 : Attack
{
	private void Start()
	{
		audioClip = (AudioClip)Resources.Load("Sounds/ATTACK5");
		audioSource.volume = 0.3f;
	}
	public override IEnumerator SpawnBullets(Vector2 userPosition)
	{
		NewBullet(BulletTypes.Spade, new Vector2(-6, Random.Range(-4.5f, 4)), Quaternion.Euler(180, 0, -90), 1, BulletBehaviours.None);
		NewBullet(BulletTypes.Spade, new Vector2(3, Random.Range(-4.5f, 4)), Quaternion.Euler(180, 0, 90), 1, BulletBehaviours.None);
		audioSource.PlayOneShot(audioClip);
		yield return new WaitForEndOfFrame();
	}
}
