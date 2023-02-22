/*
 * Ian Connors
 * MainMenuManager.cs
 * CIS 450 Assignment 5 - Simple Factory Pattern
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
	private void Start()
	{
		optionsMenu = GameObject.FindGameObjectWithTag("OptionsMenu");
		controlsMenu = GameObject.FindGameObjectWithTag("ControlsMenu");
		controlsMenu.SetActive(false);
	}
	public void LoadLevel(string levelName)
	{
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
	}
    public void SwitchMenu(string menu)
	{
        if (menu == "Options")
        {
            optionsMenu.SetActive(true);
            controlsMenu.SetActive(false);
		}
		else
		{
            controlsMenu.SetActive(true);
            optionsMenu.SetActive(false);
		}
    }
}
