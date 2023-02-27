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
			transform.up = Vector3.RotateTowards(transform.up, targetDirection, 10f * Time.deltaTime, 0);
			//rigid.MoveRotation(transform.rotation);
			rigid.velocity = rigid.velocity.magnitude * transform.up;
		}
		if (targetDirection != seekingTarget.transform.position - transform.position)
		{
			//transform.up = targetDirection;
			transform.up = Vector3.RotateTowards(transform.up, targetDirection, 10f * Time.deltaTime, 0);

			//rigid.MoveRotation(transform.rotation);
			rigid.velocity = rigid.velocity.magnitude * transform.up;
		}
	}
}
