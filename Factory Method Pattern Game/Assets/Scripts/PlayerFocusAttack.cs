/*
 * Ian Connors
 * PlayerAttack.cs
 * CIS 450 Assignment 6 - Factory Method Pattern
 * The attack the player uses when focused
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFocusAttack : Attack
{
	private void Start()
	{
		audioClip = (AudioClip)Resources.Load("Sounds/ATTACK5");
		audioSource.volume = 0.2f;
	}
	public override IEnumerator SpawnBullets(Vector2 userPosition)
	{
		NewBullet(BulletTypes.Diamond, new Vector2(userPosition.x - .3f, userPosition.y), Quaternion.identity, 7, BulletBehaviours.None);
		NewBullet(BulletTypes.Diamond, new Vector2(userPosition.x + .3f, userPosition.y), Quaternion.identity, 7, BulletBehaviours.None);
		NewBullet(BulletTypes.Heart, userPosition, Quaternion.identity, 5, BulletBehaviours.Seeking);
		audioSource.PlayOneShot(audioClip);
		yield return new WaitForEndOfFrame();
	}
}
