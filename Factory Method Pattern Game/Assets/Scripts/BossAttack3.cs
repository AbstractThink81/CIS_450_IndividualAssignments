/*
 * Ian Connors
 * BossAttack1.cs
 * CIS 450 Assignment 5 - Simple Factory Pattern
 * One of the attacks for the boss
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack3 : Attack
{
	private void Start()
	{
		audioClip = (AudioClip)Resources.Load("Sounds/ATTACK5");
		audioSource.volume = 0.3f;
	}
	public override IEnumerator SpawnBullets(Vector2 userPosition, bool focus)
	{
		NewBullet(BulletTypes.Clump, new Vector2(Random.Range(-6, 3), 4.5f), Quaternion.identity, 0, BulletBehaviours.Directed);
		audioSource.PlayOneShot(audioClip);
		yield return new WaitForEndOfFrame();
	}
}
