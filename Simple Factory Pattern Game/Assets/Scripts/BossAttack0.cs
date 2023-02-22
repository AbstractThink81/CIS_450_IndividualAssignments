/*
 * Ian Connors
 * BossAttack0.cs
 * CIS 450 Assignment 5 - Simple Factory Pattern
 * One of the attacks for the boss
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack0 : Attack
{
	private void Start()
	{
		audioClip = (AudioClip)Resources.Load("Sounds/ATTACK4");
		audioSource.volume = 0.3f;
	}
	public override IEnumerator SpawnBullets(Vector2 userPosition, bool focus)
	{
		NewBullet(2, userPosition, Quaternion.Euler(180, 0, -70), 5);
		yield return new WaitForFixedUpdate();
		NewBullet(2, userPosition, Quaternion.Euler(180, 0, -50), 5);
		yield return new WaitForFixedUpdate();
		NewBullet(2, userPosition, Quaternion.Euler(180, 0, -30), 5);
		yield return new WaitForFixedUpdate();
		NewBullet(2, userPosition, Quaternion.Euler(180, 0, -10), 5);
		yield return new WaitForFixedUpdate();
		NewBullet(2, userPosition, Quaternion.Euler(180, 0, 10), 5);
		yield return new WaitForFixedUpdate();
		NewBullet(2, userPosition, Quaternion.Euler(180, 0, 30), 5);
		yield return new WaitForFixedUpdate();
		NewBullet(2, userPosition, Quaternion.Euler(180, 0, 50), 5);
		yield return new WaitForFixedUpdate();
		NewBullet(2, userPosition, Quaternion.Euler(180, 0, 70), 5);
		yield return new WaitForFixedUpdate();
		audioSource.PlayOneShot(audioClip);
		yield return new WaitForEndOfFrame();
	}
}
