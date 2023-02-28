/*
 * Ian Connors
 * DirectedBullet.cs
 * CIS 450 Assignment 6 - Factory Method Pattern
 * Bullet that moves toward a certain location and explodes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedBullet : Bullet
{
	public Vector3 targetPosition = Vector3.zero;
	public BossAttack3 attack;
	//private Rigidbody2D rigid;
	private void Start()
	{
		//rigid = GetComponent<Rigidbody2D>();
	}
	void Update()
    {
		if (targetPosition != Vector3.zero)
		{
			Vector3 nextPos = Vector3.MoveTowards(transform.position, targetPosition, 6 * Time.deltaTime);
			transform.rotation = LookAt2D(nextPos - transform.position);
			transform.position = nextPos;
			//Vector3.Lerp(transform.position, targetPosition, 4 * Time.deltaTime);
		}
		if(transform.position == targetPosition)
		{
			transform.rotation = Quaternion.identity;
			StartCoroutine(WaitThenExplode());
		}
	}
	IEnumerator WaitThenExplode()
	{
		yield return new WaitForSeconds(0.25f);
		attack.ClumpExplode(this.gameObject);
	}
	static Quaternion LookAt2D(Vector2 forward)
	{
		return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
	}
}
