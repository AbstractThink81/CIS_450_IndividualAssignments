/*
 * Ian Connors
 * QuizManager.cs
 * CIS 450 Assignment 3 (Observer Pattern)
 * Implements ISubject and manages data about quiz questions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour, ISubject
{
	private List<IObserver> observers = new();
	[SerializeField] private List<QuizQuestion> questions;
	private int currentQuesitonIndex;

	private void Start()
	{
		currentQuesitonIndex = 1;
		RegisterObserver(GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>());
		RegisterObserver(GameObject.FindGameObjectWithTag("AnimationManager").GetComponent<AnimationManager>());
		NotifyNextQuestion(questions[currentQuesitonIndex]);
	}
	public void NotifyCorrectAnswer()
	{
		foreach (IObserver observer in observers)
		{
			observer.CorrectAnswer();
		}
	}
	public void NotifyIncorrectAnswer()
	{
		foreach (IObserver observer in observers)
		{
			observer.IncorrectAnswer();
		}
	}
	public void NotifyNextQuestion(QuizQuestion question)
	{
		foreach (IObserver observer in observers)
		{
			observer.UpdateData(question);
		}
	}

	public void RegisterObserver(IObserver observer)
	{
		observers.Add(observer);
	}

	public void RemoveObserver(IObserver observer)
	{
		observers.Remove(observer);
	}

	public void PickedOption(int optionIndex)
	{
		if (optionIndex == questions[currentQuesitonIndex].correctAnswerIndex)
		{
			currentQuesitonIndex++;
			NotifyCorrectAnswer();
			StartCoroutine(WaitThenNotify(1f));
		}
		else
		{
			if (questions[currentQuesitonIndex].questionNumber < 100)
			{
				currentQuesitonIndex = 0;
				NotifyIncorrectAnswer();
			}
			else
			{
				currentQuesitonIndex = 1;
				NotifyCorrectAnswer();
			}
			StartCoroutine(WaitThenNotify(1f));
		}
	}
	private IEnumerator WaitThenNotify(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		NotifyNextQuestion(questions[currentQuesitonIndex]);
	}
}
