/*
 * Ian Connors
 * Path.cs
 * CIS 450 Assignment 2 (revised version of a script from another project)
 * Keeps track of vertex data for paths
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
	public List<Transform> vertices = new List<Transform>();
	private void Awake()
	{
		foreach (MeshRenderer child in transform.GetComponentsInChildren<MeshRenderer>())
		{
			vertices.Add(child.gameObject.transform);
		}
	}

}