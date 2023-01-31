/*
 * Ian Connors
 * Blue.cs
 * CIS 450 Assignment 2
 * Child class for blue cubes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : Variety
{
	public override int pointValue()
	{
		return 100;
	}
	public override Material GetMaterial()
	{
		return (Material)Resources.Load("Blue");
	}
	public override int GetVarietyIndex()
	{
		return 3;
	}
}
