/*
* Ian Connors
* GameManager.cs
* CIS 450 - Assignment 12
* Manages the main functionality of the game
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float fallSpeed;

    public float gridSpaceSize;
    public int gridXCount;
    public int gridYCount;
    public Vector2 bottomLeftGridSpace;
    public Kanji[,] spaceOccupied;

    public bool gameOver;
    public bool controlsLocked;
    public bool isPaused;
    public bool isPausePaused;
    public bool tutorialPause;
    private bool canUnpause;
    private int tutorialKanjiSpawned = 0;
    public MonoBehaviour mutexHolder = null;

    //public List<Kanji> kanjiOnScreen;
    public Kanji fallingKanji;
    public List<Kanji> kanjiStragglers;
    public static bool[] kanjiUnlocked;
    private GameObject cheatSheet;
    private GameObject newKanjiPopup;
    private GameObject goalPopup;
    private GameObject goal;
    private GameObject forecastDisplay;
    private List<GameObject> cheatSheetObjects = new List<GameObject>();

    private GameObject winScreen;
    private GameObject loseScreen;
    private GameObject pauseScreen;

    private Queue<string> forecast = new Queue<string>();
    public void SetGoalText(string text)
	{
        goal.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }
	private void Start()
    {

        isPaused = true;
        isPausePaused = false;
        tutorialPause = false;
        Time.timeScale = 0;
        canUnpause = true;
        instance = this;
        spaceOccupied = new Kanji[gridXCount, gridYCount];
        gameOver = false;
        
        //if (PlayerPrefs.GetInt("AmountOfKanjiUnlocked") == 0)
		//{
            kanjiUnlocked = new bool[KanjiDictionary.kanji.Count];
		//}
		/*else
		{
            kanjiUnlocked = new bool[KanjiDictionary.kanji.Count];
            for (int i = 0; i < kanjiUnlocked.Length; i ++)
            {
                kanjiUnlocked[i] = PlayerPrefs.GetInt("Kanji" + KanjiDictionary.kanji[i] + "Unlocked") == 1;

            };

        }*/

        cheatSheet = GameObject.FindGameObjectWithTag("CheatSheet");
        newKanjiPopup = GameObject.FindGameObjectWithTag("NewKanjiPopup");
        newKanjiPopup.SetActive(false);
        goalPopup = GameObject.FindGameObjectWithTag("GoalPopup");
        goalPopup.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "\t" + GoalDictionary.goals[GoalDictionary.goalIndex];
        goal = GameObject.FindGameObjectWithTag("Goal");
        goal.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = GoalDictionary.goals[GoalDictionary.goalIndex];
        forecastDisplay = GameObject.FindGameObjectWithTag("Forecast");

        winScreen = GameObject.FindGameObjectWithTag("WinScreen");
        loseScreen = GameObject.FindGameObjectWithTag("LoseScreen");
        pauseScreen = GameObject.FindGameObjectWithTag("PauseScreen");

        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        pauseScreen.SetActive(false);
        if (GoalDictionary.isTutorial)
		{
            tutorialPause = true;
            controlsLocked = true;
            SetGoalText(GoalDictionary.tutorialText[0]);
		}
        if (!GoalDictionary.isTutorial)
        {
            while (forecast.Count < 4)
            {
                forecast.Enqueue(ForecastUpdate(GoalDictionary.kanjiSpawnRates[GoalDictionary.goalIndex][Random.Range(0, GoalDictionary.kanjiSpawnRates[GoalDictionary.goalIndex].Length)]));
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
			{
                forecast.Enqueue(ForecastUpdate(GoalDictionary.kanjiSpawnRates[0][i]));

            }
        }




        SetupCompoundCheatSheet();
        StartCoroutine(BlockFall());
    }
    public void TryGetMutex(MonoBehaviour script)
	{

	}
    public void OpenWinScreen()
	{
        winScreen.SetActive(true);
        Time.timeScale = 0;
        canUnpause = true;
	}
    public void UnlockKanji(Kanji character)
    {
        if (!kanjiUnlocked[KanjiDictionary.kanji.IndexOf(character.character)])
        {
            if (PlayerPrefs.GetInt("Kanji"+ character.character + "Unlocked") == 0)
			{

                if (KanjiDictionary.kanjiRadicals.Contains(character.character))
                {
                    newKanjiPopup.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "NEW KANJI RADICAL!";
                }
                else
                {
                    newKanjiPopup.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "NEW KANJI COMPOUND!";
                }
                newKanjiPopup.SetActive(true);
                newKanjiPopup.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = character.character;
                newKanjiPopup.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Components:\n" + character.ListComponents();
                if (KanjiDictionary.kanjiCommonality.TryGetValue(character.character, out KanjiDictionary.Commonality comm))
                    newKanjiPopup.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = comm.ToString().ToUpper();
                if (KanjiDictionary.kanjiWords.TryGetValue(character.character, out string output))
                    newKanjiPopup.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Example Words:\n" + output;
                if (KanjiDictionary.kanjiMeanings.TryGetValue(character.character, out output))
                    newKanjiPopup.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = output;

                //PlayerPrefs.SetInt("AmountOfKanjiUnlocked", PlayerPrefs.GetInt("AmountOfKanjiUnlocked") + 1);
                //var foo = true;
                // Save boolean using PlayerPrefs
                PlayerPrefs.SetInt("Kanji" + character.character + "Unlocked", 1);
                // Get boolean using PlayerPrefs
                //foo = PlayerPrefs.GetInt("foo") == 1 ? true : false;


                kanjiUnlocked[KanjiDictionary.kanji.IndexOf(character.character)] = true;
                Time.timeScale = 0;
                isPaused = true;
                canUnpause = true;
            }
            if (KanjiDictionary.finalCompounds.Contains(character.character))
            {
                cheatSheetObjects[KanjiDictionary.finalCompounds.IndexOf(character.character)].GetComponent<TextMeshProUGUI>().enabled = true;
                cheatSheetObjects[KanjiDictionary.finalCompounds.IndexOf(character.character)].GetComponent<TextMeshProUGUI>().color = Color.white;


                kanjiUnlocked[KanjiDictionary.kanji.IndexOf(character.character)] = true;
            }
        }
    }
    private void SetupCompoundCheatSheet()
	{
        for (int i = 0; i < 5; i++)
		{
            for (int j = 0; j < 4; j++)
			{
                if (i * 4 + j == KanjiDictionary.finalCompounds.Count)
				{
                    return;
				}
                GameObject newCompound = (GameObject) Instantiate(Resources.Load("Prefabs/DisplayKanji"), cheatSheet.transform.GetChild(i + 1));
                newCompound.GetComponent<TextMeshProUGUI>().text = KanjiDictionary.finalCompounds[i * 4 + j];
                string value;
                if (KanjiDictionary.kanjiMeanings.TryGetValue(KanjiDictionary.finalCompounds[i * 4 + j], out value))
                    newCompound.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = value;
                if (KanjiDictionary.kanjiCommonality.TryGetValue(KanjiDictionary.finalCompounds[i * 4 + j], out KanjiDictionary.Commonality comm))
                    newCompound.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = comm.ToString().ToUpper();
                if (PlayerPrefs.GetInt("Kanji"+KanjiDictionary.finalCompounds[i * 4 + j] + "Unlocked") == 0)
				{
                    newCompound.GetComponent<TextMeshProUGUI>().enabled = false;
				}
				else
				{
                    newCompound.GetComponent<TextMeshProUGUI>().color = Color.gray;
                }
                cheatSheetObjects.Add(newCompound);
            }
		}
	}

	private void Update()
	{
        //new kanji screen
        if (canUnpause && !gameOver && !isPausePaused && Input.anyKeyDown)
		{
            newKanjiPopup.SetActive(false);
            goalPopup.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
            canUnpause = false;
		}
        //game over and victory screens
        else if (canUnpause && gameOver)
		{
            if (Input.GetKeyDown(KeyCode.R))
			{
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
			}
            else if (Input.GetKeyDown(KeyCode.E))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            }
        }
        //pause screen
        else if (canUnpause && isPausePaused)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
                isPausePaused = false;
                canUnpause = false;
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            }
		}
        //pausing
		else if (!tutorialPause)
		{
            if (Input.GetKeyDown(KeyCode.P))
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
                isPausePaused = true;
                isPaused = true;
                canUnpause = true;
            }
        }
		//tutorial
		else
		{
            if (GoalDictionary.tutorialStep < 5)
			{
                if (Input.anyKeyDown)
                {
                    controlsLocked = false;
                    tutorialPause = false;
                }
			}
			else
			{
                GoalDictionary.goalCurrentCount++;
                GoalDictionary.instance.goalCounterText.GetComponent<TextMeshProUGUI>().text = "1/1";
                StopAllCoroutines();
                gameOver = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
                }
            }
		}
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !gameOver && !controlsLocked && !isPaused)
            {
                //iterate through all x positions starting from the left
                for (int i = 0; i < gridXCount; i++)
				{
                    //iterate through all y positions starting from the bottom
                    for (int j = 0; j < gridYCount; j++)
					{
                        //if the kanji in position (i, j) exists and has been placed, move it to the left
                        if (spaceOccupied[i,j] != null)
                        {
                            Kanji currentKanji = spaceOccupied[i, j];
                            if (currentKanji.isPlaced)
                            {
                                bool canStillMove = true;
                                while (canStillMove)
                                    canStillMove = currentKanji.MoveKanjiLeft();
                            }
                        }
                    }
                }
                StartStragglersCoroutine();
            if (GoalDictionary.isTutorial && GoalDictionary.tutorialStep == 1)
            {
                GoalDictionary.tutorialStep = 2;
                SetGoalText(GoalDictionary.tutorialText[GoalDictionary.tutorialStep]);
                tutorialPause = true;
                controlsLocked = true;
            }
        }
            if (Input.GetKeyDown(KeyCode.RightArrow) && !gameOver && !controlsLocked && !isPaused)
            {

                //iterate through all x positions starting from the right
                for (int i = gridXCount - 1; i >= 0; i--)
                {
                    //iterate through all y positions starting from the bottom
                    for (int j = 0; j < gridYCount; j++)
                    {
                        //if the kanji in position (i, j) exists and has been placed, move it to the right
                        if (spaceOccupied[i,j] != null)
                        {
                            Kanji currentKanji = spaceOccupied[i, j];
                            if (currentKanji.isPlaced)
                            {
                                bool canStillMove = true;
                                while (canStillMove)
                                    canStillMove = currentKanji.MoveKanjiRight();
                            }
                        }
                        
                    }
                }
                StartStragglersCoroutine();
            if (GoalDictionary.isTutorial && GoalDictionary.tutorialStep == 1)
            {
                GoalDictionary.tutorialStep = 2;
                SetGoalText(GoalDictionary.tutorialText[GoalDictionary.tutorialStep]);
                tutorialPause = true;
                controlsLocked = true;
            }
        }
            if (Input.GetKeyDown(KeyCode.DownArrow) && !gameOver && !controlsLocked && !isPaused)
            {
                //iterate through all y positions starting from the 1 above the bottom
                for (int i = 1; i < gridYCount; i++)
                {
                    //iterate through all x positions starting from the left
                    for (int j = 0; j < gridXCount; j++)
                    {
                        //if the kanji in position (i, j) exists and has been placed, move it to the right
                        if (spaceOccupied[j, i] != null)
                        {
                            Kanji currentKanji = spaceOccupied[j, i];
                            if (currentKanji.isPlaced)
                            {
                                bool canStillMove = true;
                                while (canStillMove)
                                    canStillMove = currentKanji.MoveKanjiDown();
                            }
                        }

                    }
                }
                StartStragglersCoroutine();
            }
            if (Input.GetKeyDown(KeyCode.A) && !gameOver && !controlsLocked && !isPaused)
            {
                if (fallingKanji != null)
                    fallingKanji.MoveKanjiLeft();
            }
            if (Input.GetKeyDown(KeyCode.D) && !gameOver && !controlsLocked && !isPaused)
            {
                if (fallingKanji != null)
                    fallingKanji.MoveKanjiRight();
            }
        
    }
    public void StartStragglersCoroutine()
	{
        //controlsLocked = true;
        StartCoroutine(ManageStragglers());
	}
    private IEnumerator ManageStragglers()
    {
        if (controlsLocked)
            yield return new WaitUntil(() => !controlsLocked);
        controlsLocked = true;
        if (mutexHolder != null)
            yield return new WaitUntil(() => mutexHolder == null);
        mutexHolder = this;
        //manage stragglers
        //iterate through all y positions
        if (kanjiStragglers.Count == 0)
        {
            for (int i = 0; i < gridYCount; i++)
            {
                //iterate through all x positions
                for (int j = 0; j < gridXCount; j++)
                {
                    //if kanji at (j, i) exists and can be moved down, add it to kanjiStragglers
                    if (spaceOccupied[j, i] != null)
                    {
                        if (spaceOccupied[j, i].isPlaced && spaceOccupied[j, i].CanMoveDown())
                        {
                            kanjiStragglers.Add(spaceOccupied[j, i]);
                        }
                    }
                }


                //make all kanji stragglers at y position i fall
                if (kanjiStragglers.Count > 0)
                {

                    bool[] doneFalling = new bool[kanjiStragglers.Count];
                    bool moreStragglers = true;
                    while (moreStragglers)
                    {
                        //kanji fall
                        yield return new WaitForSeconds((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.S)) ? 0.1f : (0.4f / fallSpeed));

                        for (int k = 0; k < kanjiStragglers.Count; k++)
                        {
                            if (!doneFalling[k])
                            {
                                doneFalling[k] = !kanjiStragglers[k].MoveKanjiDown();
                            }
                        }
                        //check to see if there are still more stragglers
                        moreStragglers = false;
                        foreach (bool b in doneFalling)
                        {
                            if (b == false)
                            {
                                moreStragglers = true;
                            }
                        }
                    }
                }
                //clear the list of stragglers so that stragglers at the next y position can be managed
                kanjiStragglers.Clear();
            }
        }

        mutexHolder = null; 
        controlsLocked = false;
    }
    private string ForecastUpdate(string newCharacter)
	{
        for (int i = 0; i < 3; i++)
        {
            forecastDisplay.transform.GetChild(1).GetChild(i).GetComponent<TextMeshProUGUI>().text = forecastDisplay.transform.GetChild(1).GetChild(i + 1).GetComponent<TextMeshProUGUI>().text;
            
            forecastDisplay.transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = forecastDisplay.transform.GetChild(1).GetChild(i + 1).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        }
        forecastDisplay.transform.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>().text = newCharacter;

        if (KanjiDictionary.kanjiMeanings.TryGetValue(newCharacter, out string output))
            forecastDisplay.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = output;
		else
            forecastDisplay.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";

        return newCharacter;
	}

	private IEnumerator BlockFall()
    {
        while (!gameOver)
        {
            if(GoalDictionary.isTutorial && GoalDictionary.tutorialStep == 1)
                yield return new WaitUntil(() => GoalDictionary.tutorialStep == 2);
            //step 2, kanji spawned 1 is ok
            //step 3, kanji spawned 2 is ok
            else if (GoalDictionary.isTutorial && GoalDictionary.tutorialStep != 0 && GoalDictionary.tutorialStep != 1 + tutorialKanjiSpawned)
                yield return new WaitUntil(() => GoalDictionary.tutorialStep == 1 + tutorialKanjiSpawned);


            if (controlsLocked)
                yield return new WaitUntil(() => !controlsLocked);
            yield return new WaitForSeconds(1 / fallSpeed);
            //spawn a new kanji
            GameObject radicalToSpawn;
            if (!GoalDictionary.isTutorial)
			{
                //ForecastUpdate(false, "");
                radicalToSpawn = (GameObject)Resources.Load("Prefabs/" + forecast.Dequeue() + " radical");
                while (forecast.Count < 4)
                {
                    forecast.Enqueue(ForecastUpdate(GoalDictionary.kanjiSpawnRates[GoalDictionary.goalIndex][Random.Range(0, GoalDictionary.kanjiSpawnRates[GoalDictionary.goalIndex].Length)]));
                }

            }
			else
			{
                //ForecastUpdate(false, "");
                radicalToSpawn = (GameObject)Resources.Load("Prefabs/" + forecast.Dequeue() + " radical");
                tutorialKanjiSpawned++;

                while (forecast.Count < 4)
                {
                    forecast.Enqueue(ForecastUpdate(""));
                }
            }

            int spawnXPosition = Random.Range(0, gridXCount);
            Vector2 spawnPosition = new Vector2(bottomLeftGridSpace.x + spawnXPosition * gridSpaceSize, bottomLeftGridSpace.y + (gridYCount - 1) * gridSpaceSize);
            fallingKanji = Instantiate(radicalToSpawn, spawnPosition, Quaternion.identity).GetComponent<Kanji>();
            UnlockKanji(fallingKanji);
            if (spaceOccupied[spawnXPosition, gridYCount - 1])
            {
                GameOver();
            }
            fallingKanji.SetSpawnPosition(spawnXPosition, gridYCount - 1);
            fallingKanji.isPlaced = false;
            //new kanji falls
            bool stillFalling = true;
            while (stillFalling)
            {
                if (controlsLocked)
                    yield return new WaitUntil(() => !controlsLocked);

                yield return new WaitForSeconds((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.S)) ? 0.1f : (1 / fallSpeed));
                
                stillFalling = fallingKanji.MoveKanjiDown();
            }
            fallingKanji = null;

            if (GoalDictionary.isTutorial && GoalDictionary.tutorialStep == 0)
            {
                GoalDictionary.tutorialStep = 1;
                SetGoalText(GoalDictionary.tutorialText[GoalDictionary.tutorialStep]);
                tutorialPause = true;
                controlsLocked = true;
            }
        }
    }
    public void GameOver()
	{
        StopAllCoroutines();
        gameOver = true;
        loseScreen.SetActive(true);
        Time.timeScale = 0;
        canUnpause = true;
    }
}
