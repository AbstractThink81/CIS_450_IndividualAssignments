/*
 * Ian Connors
 * Bullet.cs
 * CIS 450 Assignment 6 - Factory Method Pattern
 * Base class for all bullets
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public Attack.BulletTypes bulletType;
	public Attack.BulletBehaviours bulletBehaviour;
	private void Start()
	{
	}
}
