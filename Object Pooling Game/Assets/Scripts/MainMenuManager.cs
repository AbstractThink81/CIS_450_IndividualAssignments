/*
 * Ian Connors
 * MainMenuManager.cs
 * CIS 450 - Assigment 10
 * Manages UI in the Main Menu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI smallScore;
    public TextMeshProUGUI mediumScore;
    public TextMeshProUGUI largeScore;

    public void Start()
	{

        smallScore.text = "ベスト " + (PlayerPrefs.GetInt("secondsBest0") > 0 ? GameManager.TimeToString(PlayerPrefs.GetInt("secondsBest0")) : GameManager.TimeToString(480));
        mediumScore.text = "ベスト " + (PlayerPrefs.GetInt("secondsBest1") > 0 ? GameManager.TimeToString(PlayerPrefs.GetInt("secondsBest1")) : GameManager.TimeToString(480));
        largeScore.text = "ベスト " + (PlayerPrefs.GetInt("secondsBest2") > 0 ? GameManager.TimeToString(PlayerPrefs.GetInt("secondsBest2")) : GameManager.TimeToString(480));

    }
    public void OnClick(int buttonIndex)
    {
        GameManager.difficultyIndex = buttonIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
