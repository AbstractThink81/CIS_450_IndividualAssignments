/*
 * Ian Connors
 * PlayerAttack.cs
 * CIS 450 Assignment 5 - Simple Factory Pattern
 * The attack the player uses
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Attack
{
	private void Start()
	{
		audioClip = (AudioClip)Resources.Load("Sounds/ATTACK5");
		audioSource.volume = 0.2f;
	}
	public override IEnumerator SpawnBullets(Vector2 userPosition, bool focus)
	{
		NewBullet(4, userPosition, Quaternion.identity, 5);
		if (focus)
		{
			NewBullet(5, new Vector2(userPosition.x - .3f, userPosition.y), Quaternion.identity, 7);
			NewBullet(5, new Vector2(userPosition.x + .3f, userPosition.y), Quaternion.identity, 7);
		}
		audioSource.PlayOneShot(audioClip);
		yield return new WaitForEndOfFrame();
	}
}
