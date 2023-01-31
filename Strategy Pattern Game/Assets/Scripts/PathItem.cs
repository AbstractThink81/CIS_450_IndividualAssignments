/*
 * Ian Connors
 * PathItem.cs
 * CIS 450 Assignment 2 (revised version of a script from another project)
 * Makes the cubes move along their respective paths
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathItem : MonoBehaviour
{
    private int currentVertexNumber;
    private Transform nextVertex;
    public Path pathScript;
    public float speed;
    public Variety variety;
	private void Start()
	{
        currentVertexNumber = 0;
        nextVertex = pathScript.vertices[0];
	}
	void Update()
    {
        if (transform.position != nextVertex.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextVertex.position, speed * Time.deltaTime);
        }
        else
        {
            if (currentVertexNumber + 1 < pathScript.vertices.Count)
			{
                currentVertexNumber++;
                nextVertex = pathScript.vertices[currentVertexNumber];

            }
            transform.position = Vector3.MoveTowards(transform.position, nextVertex.position, speed *Time.deltaTime);

        }
    }
}
