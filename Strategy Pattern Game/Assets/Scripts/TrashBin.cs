/*
 * Ian Connors
 * TrashBin.cs
 * CIS 450 Assignment 2
 * Deletes cubes that get to the end of the trash path
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PathItem>())
            Destroy(other.gameObject);
    }
}
