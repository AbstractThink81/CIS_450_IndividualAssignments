/*
 * Ian Connors
 * MenuManager.cs
 * CIS 450 - Assigment 10
 * Manages UI during the gameplay
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    //singleton code
    public static MenuManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //menu manager code
    public GameObject pauseScreen;
    public GameObject retryScreen;
    public GameObject titleReturnScreen;
    public GameObject winScreen;

	public enum ButtonNames { 
        PauseMenu,//0
        RetryMenu,
        TitleReturnMenu,
        PauseContinue,//3
        RetryYes,
        RetryCancel,
        TitleReturnYes,//6
        TitleReturnCancel,
        WinRetry,
        WinTitle//9

    }
    public void OnGameOver(int seconds, int secondsBest, bool newRecord)
	{
        winScreen.SetActive(true);
        GameObject.FindGameObjectWithTag("TimeText").GetComponent<TextMeshProUGUI>().text = "ŽžŠÔ " + GameManager.TimeToString(seconds);
        GameObject.FindGameObjectWithTag("BestTimeText").GetComponent<TextMeshProUGUI>().text = GameManager.difficulties[GameManager.difficultyIndex] + "ƒxƒXƒg " + GameManager.TimeToString(secondsBest);
        if (!newRecord) GameObject.FindGameObjectWithTag("BestTimeText").GetComponent<TextMeshProUGUI>().color = new Color32(200, 200, 200, 255);
        GameObject.FindGameObjectWithTag("NewRecordText").SetActive(newRecord);
        Time.timeScale = 0;
    }
    public void OnClick(int buttonIndex)
	{
        ButtonNames button = (ButtonNames)buttonIndex;
        switch (button)
		{
            case ButtonNames.PauseMenu:
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
                break;
            case ButtonNames.RetryMenu:
                retryScreen.SetActive(true);
                Time.timeScale = 0;
                break;
            case ButtonNames.TitleReturnMenu:
                titleReturnScreen.SetActive(true);
                Time.timeScale = 0;
                break;
            case ButtonNames.PauseContinue:
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
                break;
            case ButtonNames.RetryCancel:
                retryScreen.SetActive(false);
                Time.timeScale = 1;
                break;
            case ButtonNames.TitleReturnCancel:
                titleReturnScreen.SetActive(false);
                Time.timeScale = 1;
                break;
            case ButtonNames.RetryYes:
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
                break;
            case ButtonNames.TitleReturnYes:
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
                Time.timeScale = 1;
                break;
            case ButtonNames.WinRetry:
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
                break;
            case ButtonNames.WinTitle:
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
                Time.timeScale = 1;
                break;
        }
	}
}
