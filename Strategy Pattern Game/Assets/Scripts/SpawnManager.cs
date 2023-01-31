/*
 * Ian Connors
 * SpawnManager.cs
 * CIS 450 Assignment 2
 * Manages the spawning of cubes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public float gameSpeed = 5;
	public List<Path> paths = new();
    public List<GameObject> prefabs = new();
	private void Start()
	{
		StartCoroutine(PeriodicSpawn());
		StartCoroutine(TrashSpawn());
	}
	IEnumerator PeriodicSpawn()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(2f, 30f/ gameSpeed));
			int pathNumber = Random.Range(0, paths.Count -1);
			GameObject obj = Instantiate(prefabs[Random.Range(0, prefabs.Count)], paths[pathNumber].vertices[0].position, Quaternion.identity);
			obj.GetComponent<PathItem>().pathScript = paths[pathNumber];
			obj.GetComponent<PathItem>().speed = gameSpeed;
			gameSpeed += 0.1f;
		}
	}
	IEnumerator TrashSpawn()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(1f, 20f / gameSpeed));
			int pathNumber = 3;
			GameObject obj = Instantiate(prefabs[Random.Range(0, prefabs.Count - 1)], paths[pathNumber].vertices[0].position, Quaternion.identity);
			obj.GetComponent<PathItem>().pathScript = paths[pathNumber];
			obj.GetComponent<PathItem>().speed = gameSpeed;
		}
	}
}
