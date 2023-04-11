/*
 * Ian Connors
 * GameManager.cs
 * CIS 450 - Assigment 10
 * Sets up tiles and keeps track of the timer and win conditions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //singleton code
    public static GameManager instance;

	//game manager code
	public TMP_FontAsset font;
	public TextMeshProUGUI timeText;
	public TextMeshProUGUI bestTimeText;
	public List<char> characters = new List<char>();
	public List<Vector2> positions = new List<Vector2>();
	public float widthOfPlayingField;
	public int tileNumber;
	private int horizontalCount;
	private float tileWidth;

	private int score;
	int seconds;
	int secondsBest;
	public static string[] difficulties;
	public static int difficultyIndex;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		difficulties = new string[] { "¬Œ^", "’†Œ^", "‘åŒ^" };
		secondsBest = PlayerPrefs.GetInt("secondsBest" + difficultyIndex);
		if (secondsBest == 0) secondsBest = 480;
		bestTimeText.text = "ƒxƒXƒg " + TimeToString(secondsBest);
		timeText.text = "ŽžŠÔ " + TimeToString(0);
	}

	public void AddScore(int amount)
	{
		score += amount;
		if (score >= tileNumber)
		{
			GameOver();
		}
	}
	private void GameOver()
	{
		Debug.Log("Win!");
		bool newRecord = false;
		if (seconds < secondsBest)
		{
			newRecord = true;
			PlayerPrefs.SetInt("secondsBest" + difficultyIndex, seconds);
			secondsBest = seconds;
		}
		MenuManager.instance.OnGameOver(seconds, secondsBest, newRecord);
		//TODO
	}
	private void SetUpTiles(int numberOfTiles)
	{
		if (numberOfTiles % 2 != 0)
		{
			numberOfTiles++;
		}
		Debug.Log(positions.Count);
		horizontalCount = Mathf.CeilToInt(Mathf.Sqrt(numberOfTiles));
		tileWidth = widthOfPlayingField / horizontalCount;
		for (int i = 0; i < numberOfTiles; i++)
		{
			positions.Add(new Vector2((i % horizontalCount) * tileWidth - widthOfPlayingField/2, Mathf.FloorToInt(i / horizontalCount) * tileWidth * -1.5f + (widthOfPlayingField * 0.7f)));
			GameObject newSpace = ObjectPooler.instance.SpawnFromPool("space", positions[i], Quaternion.identity);
			newSpace.GetComponentInChildren<Space>().tileIndex = i;
		}
		Debug.Log(positions.Count);
		List<char> temp = new List<char>();
		for (int i = 0; i < numberOfTiles / 2; i++)
		{

			char tempChar = (char)Random.Range(0x4E00, 0x9FFF);
			while (!font.HasCharacter(tempChar))
				tempChar = (char)Random.Range(0x4E00, 0x9FFF);
			temp.Add(tempChar);
			temp.Add(tempChar);
		}
		Debug.Log("temp count is " + temp.Count);
		for (int i = numberOfTiles - 1; i >= 0; i--)
		{
			int tempIndex;
			tempIndex = Random.Range(0, i);
			characters.Add(temp[tempIndex]);
			temp.RemoveAt(tempIndex);
		}
		Debug.Log("temp count is " + temp.Count);

	}
	private void Start()
	{
		switch (difficultyIndex)
		{
			case 0:
				tileNumber = 6;
				break;
			case 1:
				tileNumber = 16;
				break;
			case 2:
				tileNumber = 36;
				break;
		}
		SetUpTiles(tileNumber);
		StartCoroutine(Timer());
	}
	private IEnumerator Timer()
	{
		seconds = 0;
		while (true)
		{
			yield return new WaitForSeconds(1f);
			seconds++;
			string s = TimeToString(seconds);
			
			timeText.text = "ŽžŠÔ " + s; 
		}
	} 
	public static string TimeToString(int sec)
	{
		//convert seconds to minutes:seconds format
		string s = System.TimeSpan.FromSeconds(sec).ToString("mm\\:ss");

		//convert standard numerals to full-width numerals
		System.Text.StringBuilder sb = new("");
		foreach (char c in s)
		{
			sb.Append((char)(c + 65248));
		}
		return sb.ToString();
		//0-9 standard is 0x30 to 0x39 (48 to 57)
		//0-9 full-width is 0xff10 to 0xff19 (65296 to 65305)
		//unicode standard-width numerals to full-width numerals conversion is +65248

	}
}
