/*
 * Ian Connors
 * Yellow.cs
 * CIS 450 Assignment 2
 * Child class for yellow cubes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : Variety
{
	public override int pointValue()
	{
		return 300;
	}
	public override Material GetMaterial()
	{
		return (Material)Resources.Load("Yellow");
	}

	public override int GetVarietyIndex()
	{
		return 1;
	}
}
