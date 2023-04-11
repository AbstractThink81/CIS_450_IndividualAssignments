using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametricAnimation2D : MonoBehaviour
{
    //public variables
    public float a;
    public float tMultiplier;
    public Strategies strategy;
    public enum Strategies
    {
        Circle,
        HalfCircleX,
        HalfCircleY,
        LemniscateOfBernoulli
    };

    //private variables
    private delegate Vector2 MoveStrategy(float a, float t);
    private List<MoveStrategy> moveStrategyArray = new List<MoveStrategy>();
    private Vector2 startPosition;


    //Monobehaviour
    private void Awake()
    {
        moveStrategyArray.Add(Circle);
        moveStrategyArray.Add(HalfCircleX);
        moveStrategyArray.Add(HalfCircleY);
        moveStrategyArray.Add(LemniscateOfBernoulli);
        startPosition = transform.localPosition;
    }
    private void FixedUpdate()
    {
        float t = tMultiplier * Time.time;
        transform.localPosition = startPosition + moveStrategyArray[(int)strategy](a, t);
    }

    //draw a circle of radius a
    private Vector2 Circle(float a, float t)
    {
        return new Vector2(
            a * Mathf.Sin(t),
            a * Mathf.Cos(t)
            );
    }

    //draw a half-circle sliced across the x-axis of radius a
    private Vector2 HalfCircleX(float a, float t)
    {
        return new Vector2(
            a * Mathf.Sin(t),
            a * Mathf.Abs(Mathf.Cos(t))
            );
    }

    //draw a half-circle sliced across the y-axis of radius a
    private Vector2 HalfCircleY(float a, float t)
    {
        return new Vector2(
            a * Mathf.Abs(Mathf.Sin(t)),
            a * Mathf.Cos(t)
            );
    }

    //draw the lemniscate of Bernoulli where a is half the distance between the foci
    private Vector2 LemniscateOfBernoulli(float a, float t)
	{
        //https://en.wikipedia.org/wiki/Lemniscate_of_Bernoulli
        return new Vector2(
            (a * Mathf.Cos(t)) / (1 + Mathf.Pow(Mathf.Sin(t), 2)),
            (a * Mathf.Sin(t) * Mathf.Cos(t)) / (1 + Mathf.Pow(Mathf.Sin(t), 2))
            );
    }
}
