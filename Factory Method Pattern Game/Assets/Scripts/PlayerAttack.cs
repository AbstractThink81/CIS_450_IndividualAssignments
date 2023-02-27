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
		NewBullet(BulletTypes.Diamond, new Vector2(userPosition.x + .3f, userPosition.y), Quaternion.Euler(0, 0, -45), 7, BulletBehaviours.None);
		NewBullet(BulletTypes.Diamond, new Vector2(userPosition.x + .15f, userPosition.y), Quaternion.Euler(0, 0, -15), 7, BulletBehaviours.None);
		NewBullet(BulletTypes.Diamond, new Vector2(userPosition.x - .15f, userPosition.y), Quaternion.Euler(0, 0, 15), 7, BulletBehaviours.None);
		NewBullet(BulletTypes.Diamond, new Vector2(userPosition.x - .3f, userPosition.y), Quaternion.Euler(0, 0, 45), 7, BulletBehaviours.None);
		NewBullet(BulletTypes.Heart, userPosition, Quaternion.identity, 5, BulletBehaviours.None);
		audioSource.PlayOneShot(audioClip);
		yield return new WaitForEndOfFrame();
	}
}
