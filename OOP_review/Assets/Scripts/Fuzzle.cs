/*
 * Ian Connors
 * Assignment 1: OOP Review
 * Abstract parent class that is inherited by some of the other classes
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fuzzle : MonoBehaviour
{
    private Color color;
	[SerializeField] protected Animator animator;
	[SerializeField] protected AudioSource audioSource;
	[SerializeField] protected SpriteRenderer spriteRenderer;
	private void Start()
	{
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		spriteRenderer = GetComponent<SpriteRenderer>();

	}
	public abstract void DoATrick();
	public void ChangeColor(Color c)
	{
		color = c;
		spriteRenderer.color = color;
	}
}
