/*
 * Ian Connors
 * BossAttack1.cs
 * CIS 450 Assignment 6 - Factory Method Pattern
 * One of the attacks for the boss
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack1 : Attack
{
	private void Start()
	{
		audioClip = (AudioClip)Resources.Load("Sounds/ATTACK4");
		audioSource.volume = 0.3f;
	}
	public override IEnumerator SpawnBullets(Vector2 userPosition)
	{
		NewBullet(BulletTypes.Ball, userPosition, Quaternion.Euler(180, 0, 0), 8, BulletBehaviours.None);
		audioSource.PlayOneShot(audioClip);
		yield return new WaitForEndOfFrame();
	}
}
