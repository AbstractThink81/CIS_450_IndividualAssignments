using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedBullet : Bullet
{
	public Vector3 targetPosition = Vector3.zero;
	private Rigidbody2D rigid;
	private void Start()
	{
		rigid = GetComponent<Rigidbody2D>();
	}
	void Update()
    {
		if (targetPosition != Vector3.zero)
		{
			//transform.up = targetDirection;
			transform.up = Vector3.RotateTowards(transform.up, targetPosition, 10f * Time.deltaTime, 0);
			//rigid.MoveRotation(transform.rotation);
			rigid.velocity = rigid.velocity.magnitude * transform.up;
		}
	}
}
