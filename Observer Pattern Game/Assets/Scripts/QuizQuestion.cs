/*
 *Ian Connors
 * QuizQuestion.cs
 * CIS 450 Assignment 3 (Observer Pattern)
 * Scriptable object that contains all data necessary for a quiz question
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuizQuestion", menuName = "ScriptableObjects/QuizQuestion", order = 1)]
public class QuizQuestion : ScriptableObject
{
    public int questionNumber;
    public string question;
    public string[] answers = new string[4];

    public int correctAnswerIndex;
    public bool seriousQuesion;
    public bool finalQuestion;
    public bool seenBefore;
}
