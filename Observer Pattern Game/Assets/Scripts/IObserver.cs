/*
 * Ian Connors
 * IObserver.cs
 * CIS 450 Assignment 3 (Observer Pattern)
 * Defines the interface for all objects observing the QuizManager
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    public void CorrectAnswer();
    public void IncorrectAnswer();
    public void UpdateData(QuizQuestion question);
}
