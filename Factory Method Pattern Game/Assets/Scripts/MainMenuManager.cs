/*
 * Ian Connors
 * MainMenuManager.cs
 * CIS 450 Assignment 6 - Factory Method Pattern
 * Controls for the main menu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    private static GameObject optionsMenu;
    private static GameObject controlsMenu;
	private static GameObject difficultyMenu;
	private void Start()
	{
		optionsMenu = GameObject.FindGameObjectWithTag("OptionsMenu");
		controlsMenu = GameObject.FindGameObjectWithTag("ControlsMenu");
		difficultyMenu = GameObject.FindGameObjectWithTag("DifficultyMenu");
		controlsMenu.SetActive(false);
		difficultyMenu.SetActive(false);
	}
	public void LoadLevel(int difficulty)
	{
		GameManager.SetDifficulty(difficulty);
		UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
		//StartCoroutine(SetupLevel(difficulty));
	}
	//IEnumerator SetupLevel(int difficulty)
	//{
		//AsyncOperation ao = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Main");
		//yield return new WaitUntil(() => ao.isDone);
		//GameManager.SetDifficulty(difficulty);
		//UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
	//}
    public void SwitchMenu(string menu)
	{
        if (menu == "Options")
        {
            optionsMenu.SetActive(true);
            controlsMenu.SetActive(false);
			difficultyMenu.SetActive(false);
		}
		else if (menu == "Controls")
		{
            controlsMenu.SetActive(true);
            optionsMenu.SetActive(false);
			difficultyMenu.SetActive(false);

		}
		else
		{
			controlsMenu.SetActive(false);
			optionsMenu.SetActive(false);
			difficultyMenu.SetActive(true);
		}
	}
}
