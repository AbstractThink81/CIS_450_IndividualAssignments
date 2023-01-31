/*
 * Ian Connors
 * GameManager.cs
 * CIS 450 Assignment 2
 * Manages the tutorial UI and game over screens
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject UI;
	public List<GameObject> text = new();
	int tutorialProgress = 0;
	public TextMeshProUGUI continueButton;
	private int buttonState; //0 = tutorial, 1 = reload
	private void Start()
	{
		Time.timeScale = 0;
		UI.SetActive(true);
	}
	public void GameLost()
	{
		//deletes any cubes still in the scene
		foreach (PathItem pi in FindObjectsOfType<PathItem>())
		{
			Destroy(pi.gameObject);
		}
		Debug.Log("You lose!");
		Time.timeScale = 0;
		UI.SetActive(true);
		foreach (GameObject go in text)
		{
			go.SetActive(false);
		}
		text[2].SetActive(true);
		continueButton.text = "Play Again";
		buttonState = 1;
	}
	public void GameWon()
	{

		//deletes any cubes still in the scene
		foreach (PathItem pi in FindObjectsOfType<PathItem>())
		{
			Destroy(pi.gameObject);
		}
		Debug.Log("You win!");
		Time.timeScale = 0;
		UI.SetActive(true);
		foreach (GameObject go in text)
		{
			go.SetActive(false);
		}
		text[3].SetActive(true);
		continueButton.text = "Play Again";
		buttonState = 1;
	}
	public void ClickButton()
	{
		switch (buttonState)
		{
			case 0:
				ContinueTutorial();
				break;
			case 1:
				Restart();
				break;
		}
	}
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void ContinueTutorial()
	{
		if (tutorialProgress == 0)
		{
			foreach (GameObject go in text)
			{
				go.SetActive(false);
			}
			text[1].SetActive(true);
			tutorialProgress++;
			continueButton.text = "Start Game";
		}
		else
		{
			Time.timeScale = 1;
			UI.SetActive(false);
		}
	}
}
