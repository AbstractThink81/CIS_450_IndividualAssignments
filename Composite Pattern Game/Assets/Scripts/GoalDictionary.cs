/*
* Ian Connors
* GoalDictionary.cs
* CIS 450 - Assignment 12
* Contains data on the goal for each level and records the progress toward the current goal
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalDictionary: MonoBehaviour
{
    public static GoalDictionary instance;
    public GameObject goalCounterText;
	private void Awake()
	{
        if (goalIndex == 0)
            isTutorial = true;
        else
            isTutorial = false;
        instance = this;
        tutorialStep = 0;
        goal2CharactersUnlocked = new bool[13];
        goalCurrentCount = 0;
        goalCounterText = GameObject.FindGameObjectWithTag("GoalCounterText");
        goalCounterText.GetComponent<TextMeshProUGUI>().text = goalCurrentCount + "/" + goalMaxCount[goalIndex];

    }
    public static int goalIndex;
    public static bool isTutorial;
    public static int tutorialStep;
    public static int goalCurrentCount;
    public static string[] goals = new string[]
    {
        "Welcome to The Kanji Pit.\nIn this game, kanji radicals will spawn from the top of the screen and fall to the bottom. You must combine these falling kanji with kanji that have already been placed.\n\tCompatible kanji can be combined to form compound characters, and you can combine these compounds further with other kanji.\n\tIf there are no more compounds that can be made with a kanji, then that kanji will disappear to clear space for new kanji. Press any key to begin the tutorial.",
        "Make the kanji ï 5 times. ï is a ghost character (—H—ì•¶š yuureimoji). It has made its way into dictionaries, but since sources are not commonly listed, it's unclear where the kanji came from or what its primary usages are. It turns out that many ghost kanji are actually used in place names.",
        "There are 13 common characters (í—pŠ¿š jouyoukanji) which can be made by directly combining the seven radicals that have been included in this game. These characters are ŒÃ, ŒÍ, —Ñ, », ‹x, •Û, ¥, ‘, –¾, ’I, X, ` and ŒÎ. Make each of them at least once. Note: This includes ŒÃ, ŒÍ, —Ñ and », which are not final compounds."
    };
    public static string[] tutorialText = new string[]
    {
        "Move a falling kanji with A and D. Hold S or space to make the kanji fall faster. Press any key to spawn the first kanji radical.",
        "Once a kanji has been placed, it can be moved left and right with the arrow keys. Kanji will combine if they are moved together and are compatible. The down arrow key can be used to combine kanji downwards. Try moving the kanji.",
        "Two “ú kanji can be combined to make ¹. Press any key to spawn the next “ú, then combine the two kanji.",
        "This compound is still compatible with more kanji, so it will not disappear yet. Try combining it with another “ú. Press any key to spawn another “ú.",
        "Players who are familiar with Japanese might think this would be a final compound, but this game supports some rare kanji. » can actually be combined with the radical –Ø to make the rare kanji ï. Press any key to spawn the –Ø.",
        "The kanji has now disappeared and has been added to the Final Compounds list since it can no longer be combined with another kanji. That's it for the tutorial. Press E to return to the main menu."

    };
    public static string[][] kanjiSpawnRates = new string[][]
    {
        new string[] {"“ú", "“ú", "“ú", "–Ø" },
        new string[] {"l", "\", "Œû", "“ú", "“ú", "“ú", "“ú", "“ú", "“ú", "“ú", "“ú", "Œ", "–Ø", "–Ø", "–Ø", "–Ø", "–Ø", "…" },
        new string[] {"l", "\", "\", "Œû", "Œû", "“ú", "“ú", "“ú", "Œ", "Œ", "–Ø", "–Ø", "–Ø", "–Ø", "…" }
    };
    public static int[] goalMaxCount = new int[]
    {
        1,
        5,
        13
    };
    public static List<string> goal2Characters = new List<string>
    {
        "ŒÃ", "ŒÍ", "—Ñ", "»", "‹x", "•Û", "¥", "‘", "–¾", "’I", "X", "`", "ŒÎ"
    };
    public static bool[] goal2CharactersUnlocked;
    ///<summary>returns true if win, return false if not win</summary>
    public bool CheckGoalConditions(Kanji newCharacter)
	{
        if (goalIndex == 0)
		{
            //tutorialStep++;
            //GameManager.instance.SetGoalText(tutorialText[tutorialStep+1]);
		}
        else if (goalIndex == 1)
		{
            if (newCharacter.character == "ï")
			{
                goalCurrentCount++;
                goalCounterText.GetComponent<TextMeshProUGUI>().text = goalCurrentCount + "/" + goalMaxCount[goalIndex];
            }
            if (goalCurrentCount == goalMaxCount[1])
			{
                Win(newCharacter);
                return true;
			}
			else
			{
                return false;
			}
		}
        else if (goalIndex == 2)
		{
            if (goal2Characters.Contains(newCharacter.character))
			{

                if (!goal2CharactersUnlocked[goal2Characters.IndexOf(newCharacter.character)])
				{
                    goal2CharactersUnlocked[goal2Characters.IndexOf(newCharacter.character)] = true;
                    goalCurrentCount++;
                    goalCounterText.GetComponent<TextMeshProUGUI>().text = goalCurrentCount + "/" + goalMaxCount[goalIndex];
                }
                if (goalCurrentCount == goalMaxCount[2])
                {
                    Win(newCharacter);
                    return true;
				}
				else
				{
                    return false;
				}
            }
		}
        return false;
	}
    private void Win(Kanji finalCharacter)
	{
        StartCoroutine(WinAnimation(finalCharacter));
	}
    private IEnumerator WinAnimation(Kanji finalCharacter)
	{

        if (GameManager.instance.controlsLocked)
            yield return new WaitUntil(() => GameManager.instance.controlsLocked == false);
        GameManager.instance.StopAllCoroutines();
        GameManager.instance.gameOver = true;

        Debug.Log("Win Animation!");
        yield return new WaitForSeconds(0.5f);
        /*GameManager.instance.spaceOccupied[finalCharacter.GetXPosition(), finalCharacter.GetYPosition()] = null;
        Destroy(finalCharacter.gameObject);
        //iterate through all y positions starting from the bottom
        for (int i = 0; i < GameManager.instance.gridYCount; i++)
        {
            //iterate through all x positions starting from the left
            for (int j = 0; j < GameManager.instance.gridXCount; j++)
            {
                //Debug.Log("Checking for kanji at " + j + ", " + i);
                //if the kanji in position (i, j) exists and has been placed, move it to the left
                if (GameManager.instance.spaceOccupied[j, i] != null)
                {
                    //Debug.Log("Found kanji at " + j + ", " + i);
                    Kanji currentKanji = GameManager.instance.spaceOccupied[i, j];
                    GameManager.instance.spaceOccupied[j, i] = null;
                    Destroy(currentKanji);
                    yield return new WaitForSeconds(0.5f);
                }
            }
        }*/
        GameManager.instance.OpenWinScreen();
    }
}
