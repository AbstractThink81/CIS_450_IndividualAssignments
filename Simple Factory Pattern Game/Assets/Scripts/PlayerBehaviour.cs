/*
 * Ian Connors
 * PlayerBehaviour.cs
 * CIS 450 Assignment 5 - Simple Factory Pattern
 * Controls the movement of the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	public float baseSpeed;
	private float speed;
	private Vector2 direction;
	private int canAttack;

	private Attack attack;
	public GameObject center;
	private void Start()
	{
		speed = baseSpeed;
		attack = gameObject.AddComponent<PlayerAttack>();
		canAttack = 0;
	}
	private void Update()
	{
		//get direction input
		direction = Vector2.zero;
		if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 4.5f)
		{
			direction += Vector2.up;
		}
		if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -4.5f)
		{
			direction += Vector2.down;
		}
		if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -6f)
		{
			direction += Vector2.left;
		}
		if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 3f)
		{
			direction += Vector2.right;
		}

		//get speed
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			speed = baseSpeed / 2.5f;
			center.SetActive(true);
		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			speed = baseSpeed;
			center.SetActive(false);
		}

		//move
		transform.Translate(direction.normalized * speed * Time.deltaTime);


		//attack
		if (Input.GetKey(KeyCode.Z) && canAttack > 6)
		{
			if (speed == baseSpeed)
			{
				attack.StartAttack(transform.position, false);
			}
			else
			{
				attack.StartAttack(transform.position, true);
			}
			canAttack = 0;
		}
	}
	public void DeathAnimation(int lives)
	{
		if (lives == 0)
		{
			GameManager.ShowEndMenu("Lose");
		}
		else
		{
			List<GameObject> bullets = new List<GameObject>();
			bullets.AddRange(GameObject.FindGameObjectsWithTag("PlayerBullet"));
			bullets.AddRange(GameObject.FindGameObjectsWithTag("BossBullet"));
			foreach (GameObject go in bullets)
			{
				Destroy(go);
			}
			transform.position = new Vector2(-1.5f, -2.5f);
		}
	}
	private void FixedUpdate()
	{
		canAttack++;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("BossBullet"))
			GameManager.PlayerHurt();
	}
}
