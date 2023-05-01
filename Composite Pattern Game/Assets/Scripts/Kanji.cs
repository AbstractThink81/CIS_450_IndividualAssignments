/*
* Ian Connors
* Kanji.cs
* CIS 450 - Assignment 12
* Implements the functionality for moving kanji and combining compatible kanji
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Kanji : MonoBehaviour
{
	private int[] currentSpace = new int[2];
	[SerializeField] public bool isPlaced;
	public string character;
	public bool canMove;
	public virtual string ListComponents()
	{
		//children should implement overrrides
		return "";
	}
	public void SetSpawnPosition(int xPosition, int yPosition)
	{
		currentSpace = new int[] { xPosition, yPosition };
		GameManager.instance.spaceOccupied[currentSpace[0], currentSpace[1]] = this;
		canMove = true;
	}
	public int GetXPosition()
	{
		return currentSpace[0];
	}
	public int GetYPosition()
	{
		return currentSpace[1];
	}
	///<summary>returns true if the kanji was moved, returns false if the kanji was blocked from moving</summary>
	public bool MoveKanjiLeft()
	{
		if (currentSpace[0] > 0 && canMove)
		{
			if (GameManager.instance.spaceOccupied[currentSpace[0] - 1, currentSpace[1]])
			{
				CheckAndCombine(GameManager.instance.spaceOccupied[currentSpace[0] - 1, currentSpace[1]]);
				return false;
			}
			else
			{
				GameManager.instance.spaceOccupied[currentSpace[0], currentSpace[1]] = null;
				currentSpace = new int[] { currentSpace[0] - 1, currentSpace[1] };
				GameManager.instance.spaceOccupied[currentSpace[0], currentSpace[1]] = this;
				transform.Translate(Vector2.left * GameManager.instance.gridSpaceSize);
				return true;
			}
		}
		else
		{
			return false;
		}
	}
	///<summary>returns true if the kanji was moved, returns false if the kanji was blocked from moving</summary>
	public bool MoveKanjiRight()
	{
		if (currentSpace[0] < GameManager.instance.gridXCount - 1 && canMove)
		{
			if (GameManager.instance.spaceOccupied[currentSpace[0] + 1, currentSpace[1]])
			{
				CheckAndCombine(GameManager.instance.spaceOccupied[currentSpace[0] + 1, currentSpace[1]]);
				return false;
			}
			else
			{
				GameManager.instance.spaceOccupied[currentSpace[0], currentSpace[1]] = null;
				currentSpace = new int[] { currentSpace[0] + 1, currentSpace[1] };
				GameManager.instance.spaceOccupied[currentSpace[0], currentSpace[1]] = this;
				transform.Translate(Vector2.right * GameManager.instance.gridSpaceSize);
				return true;
			}
		}
		else
		{
			return false;
		}
	}
	///<summary>returns true if the kanji was moved, returns false if the kanji was blocked from moving</summary>
	public bool MoveKanjiDown()
	{
		if (currentSpace[1] > 0 && canMove)
		{
			if (GameManager.instance.spaceOccupied[currentSpace[0], currentSpace[1] - 1])
			{
				CheckAndCombine(GameManager.instance.spaceOccupied[currentSpace[0], currentSpace[1] - 1]);
				if (!isPlaced)
					isPlaced = true;
				return false;
			}
			else
			{
				GameManager.instance.spaceOccupied[currentSpace[0], currentSpace[1]] = null;
				currentSpace = new int[] { currentSpace[0], currentSpace[1] - 1 };
				GameManager.instance.spaceOccupied[currentSpace[0], currentSpace[1]] = this;
				transform.Translate(Vector2.down * GameManager.instance.gridSpaceSize);
				return true;
			}
		}
		else
		{
			isPlaced = true;
			return false;
		}
	}
	public bool CanMoveDown()
	{
		if (currentSpace[1] > 0 && canMove)
		{
			if (GameManager.instance.spaceOccupied[currentSpace[0], currentSpace[1] - 1])
			{
				return false;
			}
			else
			{
				return true;
			}

		}
		else
		{
			return false;
		}
	}
	private void CheckAndCombine(Kanji otherKanji)
	{
		//check if kanji are compatible
		string compositeCharacter;
		Dictionary<string, string> outputDictionary;
		if (otherKanji.GetType() == typeof(KanjiRadical))
		{
			if (KanjiDictionary.kanjiCompounds.TryGetValue(otherKanji.character, out outputDictionary))
			{
				if (outputDictionary.TryGetValue(character, out compositeCharacter))
				{
					Combine(otherKanji, compositeCharacter);
				}
			}
		}
		else if (GetType() == typeof(KanjiRadical))
		{
			if (KanjiDictionary.kanjiCompounds.TryGetValue(character, out outputDictionary))
			{
				if (outputDictionary.TryGetValue(otherKanji.character, out compositeCharacter))
				{
					Combine(otherKanji, compositeCharacter);
				}
			}
		}

	}
	private void Combine(Kanji otherKanji, string compositeCharacter)
	{
		//combine kanji
		Debug.Log("Combining kanji");

		GameManager.instance.spaceOccupied[currentSpace[0], currentSpace[1]] = null;
		canMove = false;
		otherKanji.canMove = false;
		KanjiComposite composite = Instantiate((GameObject)Resources.Load("Prefabs/composite"), otherKanji.transform.position, Quaternion.identity).GetComponent<KanjiComposite>();
		Destroy(otherKanji.transform.GetChild(0).gameObject);
		Destroy(otherKanji.gameObject.GetComponent<SpriteRenderer>());
		Destroy(transform.GetChild(0).gameObject);
		Destroy(gameObject.GetComponent<SpriteRenderer>());
		otherKanji.transform.SetParent(composite.transform);
		transform.SetParent(composite.transform);
		composite.character = compositeCharacter;
		composite.GetComponentInChildren<TextMeshProUGUI>().text = compositeCharacter;
		composite.SetSpawnPosition(otherKanji.GetXPosition(), otherKanji.GetYPosition());
		composite.AddComponents(otherKanji, this);
		//play animation
		StartCoroutine(CombineAnimation(composite));

	}
	private IEnumerator CombineAnimation(KanjiComposite composite)
	{
		if (GameManager.instance.controlsLocked)
			yield return new WaitUntil(() => !GameManager.instance.controlsLocked);
		GameManager.instance.controlsLocked = true; 
		GameManager.instance.mutexHolder = this;
		Debug.Log("Play animation");
		if (KanjiDictionary.kanjiMeanings.TryGetValue(composite.character, out string meaning))
			composite.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = meaning;
		yield return new WaitForSeconds(0.5f);

		GameManager.instance.UnlockKanji(composite);
		if (GoalDictionary.instance.CheckGoalConditions(composite))
		{
			Debug.Log("You won!");
			GameManager.instance.mutexHolder = null;
			GameManager.instance.controlsLocked = false;

		}
		else
		{
			yield return new WaitForSeconds(0.5f);

			composite.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
			//check if final kanji
			foreach (string s in KanjiDictionary.finalCompounds)
			{
				if (s == composite.character)
				{
					GameManager.instance.spaceOccupied[composite.currentSpace[0], composite.currentSpace[1]] = null;
					Destroy(composite.gameObject);
					break;
				}
			}

			GameManager.instance.mutexHolder = null;
			GameManager.instance.controlsLocked = false;
			GameManager.instance.StartStragglersCoroutine();
			if (GoalDictionary.isTutorial && GoalDictionary.tutorialStep > 1 && GoalDictionary.tutorialStep < 5)
			{
				GoalDictionary.tutorialStep++;
				GameManager.instance.SetGoalText(GoalDictionary.tutorialText[GoalDictionary.tutorialStep]);
				GameManager.instance.tutorialPause = true;
				GameManager.instance.controlsLocked = true;
			}
		}
	}
}
