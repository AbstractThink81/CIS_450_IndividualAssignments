/*
 * Ian Connors
 * BossAttack3.cs
 * CIS 450 Assignment 6 - Factory Method Pattern
 * One of the attacks for the boss
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack3 : Attack
{
	public override IEnumerator SpawnBullets(Vector2 userPosition)
	{
		audioClip = (AudioClip)Resources.Load("Sounds/ATTACK5");
		audioSource.volume = 0.3f;
		NewBullet(BulletTypes.Clump, new Vector2(Random.Range(-6, 3), 4.5f), Quaternion.identity, 0, BulletBehaviours.Directed, GameObject.FindGameObjectWithTag("Player").transform.position);
		audioSource.PlayOneShot(audioClip);
		yield return new WaitForEndOfFrame();
	}
	public void ClumpExplode(GameObject go)
	{
		Vector3 position = go.transform.position;
		Destroy(go);
		if (GameManager.GetDifficulty() == GameManager.LevelDifficulty.Normal)
		{

			for (int i = -180; i < 180; i += 45)
			{
				NewBullet(BulletTypes.Club, position, Quaternion.Euler(180, 0, i + 22.5f), 2, BulletBehaviours.None);
			}
		}
		else if (GameManager.GetDifficulty() == GameManager.LevelDifficulty.Hard)
		{

			for (int i = -180; i < 180; i += 36)
			{
				NewBullet(BulletTypes.Club, position, Quaternion.Euler(180, 0, i), 2, BulletBehaviours.None);
				NewBullet(BulletTypes.Club, position, Quaternion.Euler(180, 0, i + Random.Range(0, 18)), 3, BulletBehaviours.None);
			}
		}
		else if (GameManager.GetDifficulty() == GameManager.LevelDifficulty.Lunatic)
		{

			for (int i = -180; i < 180; i += 24)
			{
				NewBullet(BulletTypes.Club, position, Quaternion.Euler(180, 0, i), 2, BulletBehaviours.None);
				NewBullet(BulletTypes.Club, position, Quaternion.Euler(180, 0, i + Random.Range(0, 12)), 4, BulletBehaviours.None);
				NewBullet(BulletTypes.Club, position, Quaternion.Euler(180, 0, i + Random.Range(0, 24)), 3, BulletBehaviours.None);
			}
		}
		/*NewBullet(BulletTypes.Club, position, Quaternion.Euler(180, 0, -135 + 22.5f), 3, BulletBehaviours.None);
		NewBullet(BulletTypes.Club, position, Quaternion.Euler(180, 0, -90 + 22.5f), 3, BulletBehaviours.None);
		NewBullet(BulletTypes.Club, position, Quaternion.Euler(180, 0, -45 + 22.5f), 3, BulletBehaviours.None);
		NewBullet(BulletTypes.Club, position, Quaternion.Euler(180, 0, 0 + 22.5f), 3, BulletBehaviours.None);
		NewBullet(BulletTypes.Club, position, Quaternion.Euler(180, 0, 45 + 22.5f), 3, BulletBehaviours.None);
		NewBullet(BulletTypes.Club, position, Quaternion.Euler(180, 0, 90 + 22.5f), 3, BulletBehaviours.None);
		NewBullet(BulletTypes.Club, position, Quaternion.Euler(180, 0, 135 + 22.5f), 3, BulletBehaviours.None);
		NewBullet(BulletTypes.Club, position, Quaternion.Euler(180, 0, 180 +22.5f), 3, BulletBehaviours.None);
		*/
		audioClip = (AudioClip)Resources.Load("Sounds/ATTACK3");
		audioSource.volume = 0.8f;
		audioSource.PlayOneShot(audioClip);
	}
}
