/*
 * Ian Connors
 * Green.cs
 * CIS 450 Assignment 2
 * Child class for green cubes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : Variety
{
	public override int pointValue()
	{
		return 200;
	}
	public override Material GetMaterial()
	{
		return (Material)Resources.Load("Green");
	}
	public override int GetVarietyIndex()
	{
		return 2;
	}
}
