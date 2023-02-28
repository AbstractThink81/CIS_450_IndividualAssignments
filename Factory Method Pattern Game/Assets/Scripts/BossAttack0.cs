/*
 * Ian Connors
 * BossAttack0.cs
 * CIS 450 Assignment 6 - Factory Method Pattern
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
	public override IEnumerator SpawnBullets(Vector2 userPosition)
	{
		if(GameManager.GetDifficulty() == GameManager.LevelDifficulty.Normal)
		{

			for (int i = -180; i < 180; i += 32)
			{
				NewBullet(BulletTypes.Club, userPosition, Quaternion.Euler(180, 0, i), 5, BulletBehaviours.None);
				yield return new WaitForFixedUpdate();
			}
		}else if (GameManager.GetDifficulty() == GameManager.LevelDifficulty.Hard)
		{

			for (int i = -180; i < 180; i += 16)
			{
				NewBullet(BulletTypes.Club, userPosition, Quaternion.Euler(180, 0, i), 5, BulletBehaviours.None);
				yield return new WaitForFixedUpdate();
			}
		}
		else if (GameManager.GetDifficulty() == GameManager.LevelDifficulty.Lunatic)
		{

			for (int i = -180; i <= 180; i += 8)
			{
				NewBullet(BulletTypes.Club, userPosition, Quaternion.Euler(180, 0, i), 5, BulletBehaviours.None);
				yield return new WaitForFixedUpdate();
			}
		}

		/*
		NewBullet(BulletTypes.Club, userPosition, Quaternion.Euler(180, 0, -70), 5, BulletBehaviours.None);
		yield return new WaitForFixedUpdate();
		if (GameManager.GetDifficulty() == GameManager.LevelDifficulty.Lunatic)
		{
			NewBullet(BulletTypes.Club, userPosition, Quaternion.Euler(180, 0, -60), 5, BulletBehaviours.None);
			yield return new WaitForFixedUpdate();
		}
		NewBullet(BulletTypes.Club, userPosition, Quaternion.Euler(180, 0, -50), 5, BulletBehaviours.None);
		yield return new WaitForFixedUpdate();
		NewBullet(BulletTypes.Club, userPosition, Quaternion.Euler(180, 0, -30), 5, BulletBehaviours.None);
		yield return new WaitForFixedUpdate();
		NewBullet(BulletTypes.Club, userPosition, Quaternion.Euler(180, 0, -10), 5, BulletBehaviours.None);
		yield return new WaitForFixedUpdate();
		NewBullet(BulletTypes.Club, userPosition, Quaternion.Euler(180, 0, 10), 5, BulletBehaviours.None);
		yield return new WaitForFixedUpdate();
		NewBullet(BulletTypes.Club, userPosition, Quaternion.Euler(180, 0, 30), 5, BulletBehaviours.None);
		yield return new WaitForFixedUpdate();
		NewBullet(BulletTypes.Club, userPosition, Quaternion.Euler(180, 0, 50), 5, BulletBehaviours.None);
		yield return new WaitForFixedUpdate();
		NewBullet(BulletTypes.Club, userPosition, Quaternion.Euler(180, 0, 70), 5, BulletBehaviours.None);
		yield return new WaitForFixedUpdate();*/
		audioSource.PlayOneShot(audioClip);
		yield return new WaitForEndOfFrame();
	}
}
