/*
 * Ian Connors
 * Bomb.cs
 * CIS 450 Assignment 2
 * Child class for camo cubes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Variety
{
	public override int pointValue()
	{
		return 2000;
	}
	public override Material GetMaterial()
	{
		return (Material)Resources.Load("Generator");
	}
	public override int GetVarietyIndex()
	{
		return 4;
	}
}
