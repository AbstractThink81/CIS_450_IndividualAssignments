/*
 * Ian Connors
 * GameManager.cs
 * CIS 450 Assignment 5 - Simple Factory Pattern
 * Manages core aspects of the game such as win and loss condions and UI
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameObject pauseMenu;
    private static GameObject winMenu;
    private static GameObject loseMenu;
    private static bool paused;
    private static AudioSource audioSource;
    private static int bossHealth;
    private static int playerLives = 4;
    private static Slider bossHealthSlider;
    private static TextMeshProUGUI playerHealthText;
	// Update is called once per frame
	private void Start()
	{
        Physics2D.gravity = Vector2.zero;
        audioSource = GetComponent<AudioSource>();
        bossHealthSlider = GameObject.FindGameObjectWithTag("BossSlider").GetComponent<Slider>();
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        winMenu = GameObject.FindGameObjectWithTag("WinMenu");
        loseMenu = GameObject.FindGameObjectWithTag("LoseMenu");
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        loseMenu.SetActive(false);

        bossHealth = (int)bossHealthSlider.maxValue;
        playerHealthText = GameObject.FindGameObjectWithTag("PlayerHealthText").GetComponent<TextMeshProUGUI>();
        playerLives = 4;
    }
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
		{
            if (!paused)
			{
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                paused = true;
			}
			else
			{
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                paused = false;
            }
		}
    }
    public static void StartMusic()
	{
        audioSource.Play();
	}
    public static void PlayerHurt()
	{
        Debug.Log("PlayerHurt");
        playerLives--;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().DeathAnimation(playerLives);
        GameObject.FindGameObjectWithTag("Boss").GetComponent<BossBehaviour>().canShoot = 0;
        switch (playerLives)
		{
            case 4:
                playerHealthText.text = "Player: O O O";
                break;
            case 3:
                playerHealthText.text = "Player: O O";
                break;
            case 2:
                playerHealthText.text = "Player: O";
                break;
            case 1:
                playerHealthText.text = "Player:";
                break;
        }
    }
    public static void BossHurt()
    {
        bossHealth--;
        bossHealthSlider.value = bossHealth;

        if (bossHealth == 0)
		{
            GameObject.FindGameObjectWithTag("Boss").GetComponent<BossBehaviour>().DeathAnimation();
        }
    }
    public static void ShowEndMenu(string menu)
	{
        if (menu == "Win")
		{
            winMenu.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
        if (menu == "Lose")
		{
            loseMenu.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
	}
    public void LoadLevel(string levelName)
	{
        Time.timeScale = 1;
        paused = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
	}
    public void Unpause()
	{
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        paused = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet") || collision.CompareTag("BossBullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
