/*
 * Ian Connors
 * ObjectPooler.cs
 * CIS 450 - Assigment 10
 * The abstract implementation of object pooling
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //singleton code
    public static ObjectPooler instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        FillPoolsWithInactiveObjects();
    }

    //object pooler code
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

	private void FillPoolsWithInactiveObjects() {
        Transform canvasTransform = GameObject.FindGameObjectWithTag("Canvas").transform;
        foreach (Pool p in pools)
		{
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < p.size; i++)
			{
                GameObject obj = Instantiate(p.prefab, canvasTransform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
			}
            poolDictionary.Add(p.tag, objectPool);
		}
    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {
        if (!poolDictionary.ContainsKey(tag))
		{
            Debug.LogWarning("Pool with tag " + tag + " does not exist.");
            return null;
		}
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.localPosition = position;
        objectToSpawn.transform.localRotation = rotation;
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
    public void ReturnObjectToPool(string tag, GameObject objectToReturn)
	{
        objectToReturn.SetActive(false);
        poolDictionary[tag].Enqueue(objectToReturn);
	}
}
