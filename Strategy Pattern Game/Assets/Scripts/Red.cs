/*
 * Ian Connors
 * Red.cs
 * CIS 450 Assignment 2
 * Child class for red cubes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : Variety
{
	public override int pointValue()
	{
		return 400;
	}
	public override Material GetMaterial()
	{
		return (Material)Resources.Load("Red");
	}
	public override int GetVarietyIndex()
	{
		return 0;
	}
}
