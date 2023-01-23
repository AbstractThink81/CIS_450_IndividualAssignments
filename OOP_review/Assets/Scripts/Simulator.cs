/*
 * Ian Connors
 * Assignment 1: OOP Review
 * Binds fuzzle actions to keystrokes
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : MonoBehaviour
{
    public GameObject[] fuzzles;
    private List<Fuzzle> fuzzleList = new();
    private List<ICanSleep> canSleepList = new();
    private List<ICanLaugh> canLaughList = new();

	private void Start()
	{
        for (int i = 0; i <= 4; i++)
		{
            fuzzleList.Add(fuzzles[i].GetComponent<Fuzzle>());
        }
        for (int i = 5; i <= 9; i++)
        {
            canSleepList.Add(fuzzles[i].GetComponent<ICanSleep>());
        }
        for (int i = 10; i <= 14; i++)
        {
            canLaughList.Add(fuzzles[i].GetComponent<ICanLaugh>());
        }
    }
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
		{
            foreach (Fuzzle fuzzle in fuzzleList)
			{
                fuzzle.DoATrick();
			} 
		}
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (ICanLaugh canLaugh in canLaughList)
            {
                canLaugh.Laugh();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (ICanSleep canSleep in canSleepList)
            {
                canSleep.Sleep();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (ICanSleep canSleep in canSleepList)
            {
                canSleep.WakeUp();
            }
        }
    }
}
