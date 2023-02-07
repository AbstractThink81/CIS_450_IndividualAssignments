/*
 * Ian Connors
 * ISubject.cs
 * CIS 450 Assignment 3 (Observer Pattern)
 * Defines the interface with which the QuizManager interacts with observers
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    public void RegisterObserver(IObserver observer);
    public void RemoveObserver(IObserver observer);
    public void NotifyCorrectAnswer();
    public void NotifyIncorrectAnswer();
    public void NotifyNextQuestion(QuizQuestion question);

}
