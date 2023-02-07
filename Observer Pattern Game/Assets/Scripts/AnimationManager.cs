/*
 * Ian Connors
 * AnimationManager.cs
 * CIS 450 Assignment 3 (Observer Pattern)
 * Manages the animations for the floating head character
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour, IObserver
{
	private Animator faceAnimator;
	private void Start()
	{
		faceAnimator = GameObject.FindGameObjectWithTag("Face").GetComponent<Animator>();
	}
	public void UpdateData(QuizQuestion question)
	{
		if (question.finalQuestion)
		{
			CorrectAnswer();
		}
		else
		{
			if (question.seriousQuesion)
			{
				faceAnimator.SetTrigger("BecomeSerious");
			}
			else
			{
				faceAnimator.SetTrigger("Ask");
			}
		}
	}

	public void CorrectAnswer()
	{
		faceAnimator.SetTrigger("Laugh");
	}

	public void IncorrectAnswer()
	{
		faceAnimator.SetTrigger("BeShocked");
	}
	
}
