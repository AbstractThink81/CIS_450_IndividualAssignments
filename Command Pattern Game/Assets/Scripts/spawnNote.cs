using System;
using System.Collections;
using UnityEngine;

public class spawnNote : MonoBehaviour
{
    public float multiplier;
    public float bpm;
    public GameObject note;
    // Update is called once per frame
    void Awake()
    {
        StartCoroutine(spawn());
		//StartCoroutine(spawn());
	}
	IEnumerator spawn()
	{
        int counter = 0;
        while (true)
		{

            yield return new WaitForSeconds(60f / (bpm*multiplier));
            if (counter%6 != 0)
                spawnn();
            counter++;
		}
		
	}
	private void spawnn()
	{
        Instantiate(note, transform.position, transform.rotation);
    }
}
