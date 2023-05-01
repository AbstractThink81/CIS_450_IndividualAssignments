/*
* Ian Connors
* MainMenuManager.cs
* CIS 450 - Assignment 12
* Implements the functionality of the main menu
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private GameObject selectionObject;
	public int levelSelectionDistance;
	private int levelSelectionNumber = 0;
	public int numberOfLevels;
    private void Start()
    {
        selectionObject = GameObject.FindGameObjectWithTag("SelectionObject");
    }
	private void Update()
	{
		//delete data
		/*
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			for (int i = 0; i < KanjiDictionary.kanji.Count; i++)
			{
				//kanjiUnlocked[i] = PlayerPrefs.GetInt("Kanji" + KanjiDictionary.kanji[i] + "Unlocked") == 0;
				PlayerPrefs.SetInt("Kanji" + KanjiDictionary.kanji[i] + "Unlocked", 0);

			}
		}*/
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
		{
			if (levelSelectionNumber > 0)
			{
				levelSelectionNumber--;
				selectionObject.transform.localPosition += (Vector3)Vector2.up * levelSelectionDistance;
			}
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
		{
			if (levelSelectionNumber < numberOfLevels - 1)
			{
				levelSelectionNumber++;
				selectionObject.transform.localPosition += (Vector3)Vector2.down * levelSelectionDistance;
			}
		}
		else if (Input.GetKeyDown(KeyCode.E))
		{
			GoalDictionary.goalIndex = levelSelectionNumber;
			UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
		}
	}
}
