/*
 * Ian Connors
 * Variety.cs
 * CIS 450 Assignment 2
 * Parent class for cube colors
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Variety: MonoBehaviour
{
	public abstract int pointValue();
	public abstract Material GetMaterial();
	public abstract int GetVarietyIndex();
	private void Start()
	{
		gameObject.GetComponent<MeshRenderer>().material = GetMaterial();
		if (gameObject.GetComponent<PathItem>())
			gameObject.GetComponent<PathItem>().variety = this;
	}
}
