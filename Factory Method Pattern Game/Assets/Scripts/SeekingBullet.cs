/*
 * Ian Connors
 * SeekingBullet.cs
 * CIS 450 Assignment 6 - Factory Method Pattern
 * Bullet that moves toward a gameObject target
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingBullet : Bullet
{
    public GameObject seekingTarget;
	private Vector3 targetDirection = Vector3.zero;
	private Rigidbody2D rigid;
	private void Start()
	{
		rigid = GetComponent<Rigidbody2D>();
	}
	void Update()
    {
		if (seekingTarget != null && targetDirection == Vector3.zero)
		{
			targetDirection = seekingTarget.transform.position - transform.position;
			//transform.up = targetDirection;
			transform.up = Vector3.RotateTowards(transform.up, targetDirection, 180f * Time.deltaTime, 0);
			//rigid.MoveRotation(transform.rotation);
			rigid.AddForce(transform.up * 10 * Time.deltaTime, ForceMode2D.Impulse);
		}
		if (targetDirection != seekingTarget.transform.position - transform.position)
		{
			//transform.up = targetDirection;
			transform.up = Vector3.RotateTowards(transform.up, targetDirection, 180f * Time.deltaTime, 0);

			//rigid.MoveRotation(transform.rotation);
			rigid.AddForce(transform.up * 10 * Time.deltaTime, ForceMode2D.Impulse);
		}
	}
}
