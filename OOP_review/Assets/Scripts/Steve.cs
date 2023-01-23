/*
 * Ian Connors
 * Assignment 1: OOP Review
 * Child class of Fuzzle (This is the one with the sunglasses)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steve : Fuzzle, ICanLaugh, ICanSleep
{
	public Sprite sleepSprite;
	public Sprite awakeSprite;
	public override void DoATrick()
	{
		StopAllCoroutines();
		StartCoroutine(Trick());
	}

	public void Laugh()
	{
		animator.SetTrigger("Laugh");
		audioSource.Play();
	}

	public void Sleep()
	{
		animator.SetTrigger("Sleep");
		spriteRenderer.sprite = sleepSprite;
	}

	public void WakeUp()
	{
		animator.SetTrigger("WakeUp");
		spriteRenderer.sprite = awakeSprite;
	}

	private IEnumerator Trick()
	{
		int count = 0;
		while (count < 24)
		{
			transform.Rotate(0, 0, 15);
			yield return new WaitForSeconds(0.05f);
			count++;
		}
		transform.rotation = Quaternion.identity;
	}
}
