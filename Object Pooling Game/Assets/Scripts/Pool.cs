/*
 * Ian Connors
 * Pool.cs
 * CIS 450 - Assigment 10
 * Pool data that is used by the ObjectPooler
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string tag;
    public int size;
    public GameObject prefab;
}
