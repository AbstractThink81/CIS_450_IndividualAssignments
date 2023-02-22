/*
 * Ian Connors
 * UIManager.cs
 * CIS 450 Assignment 3 (Observer Pattern)
 * Manages button input and text display
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IObserver
{
    private QuizManager quizManager;
	[SerializeField] private TextMeshProUGUI[] buttons = new TextMeshProUGUI[4];
	[SerializeField] private TextMeshProUGUI questionText;
	[SerializeField] private TextMeshProUGUI questionNumberText;
	private bool finalQuestion;
	private int textSpeed;

	public void UpdateData(QuizQuestion question)
	{
		StartCoroutine(SequentiallyUpdateData(question));
		if (question.questionNumber > 99)
		{
			finalQuestion = true;
		}
	}
	void Start()
    {
        quizManager = GameObject.FindGameObjectWithTag("QuizManager").GetComponent<QuizManager>();
		ResetUI();
		finalQuestion = false;
		textSpeed = 1;
	}
	public void OnButtonClick(int buttonIndex)
	{
		quizManager.PickedOption(buttonIndex);
	}
	private IEnumerator SequentiallyUpdateData(QuizQuestion question)
	{
		if (question.seenBefore)
		{
			textSpeed = 0;
		}
		else
		{
			textSpeed = 1;
		}
		questionText.text = "";
		questionNumberText.text = "QUESTION " + question.questionNumber;
		if (textSpeed == 1)
		{
			foreach (char c in question.question)
			{
				questionText.text += c;
				yield return new WaitForSeconds(0.02f);
			}
		}
		else
		{
			questionText.text += question.question;
		}
		
		yield return new WaitForSeconds(0.5f * textSpeed);
		for (int i = 0; i < 4; i++)
		{
			if (textSpeed == 1)
			{
				foreach (char c in question.answers[i])
				{
					buttons[i].text += c;
					yield return new WaitForSeconds(0.01f);
				}
			}
			else
			{
				buttons[i].text += question.answers[i];
			}
		}
		yield return new WaitForSeconds(0.2f);
		foreach (TextMeshProUGUI button in buttons)
		{
			button.transform.parent.gameObject.GetComponent<Button>().interactable = true;
		}
	}
	public void CorrectAnswer()
	{
		if (!finalQuestion)
		{
			ResetUI();
			questionText.text = "CORRECT!";
		}
		else
		{
			ResetUI();
			questionText.text = "COOLBEANS!";
		}
	}

	public void IncorrectAnswer()
	{
		ResetUI();
		questionText.text = "WRONG!";
	}
	private void ResetUI()
	{
		questionNumberText.text = "";
		questionText.text = "";
		foreach (TextMeshProUGUI button in buttons)
		{
			button.text = "";
			button.transform.parent.gameObject.GetComponent<Button>().interactable = false;
		}
	}
}
