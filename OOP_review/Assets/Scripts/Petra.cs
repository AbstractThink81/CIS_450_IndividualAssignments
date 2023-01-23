/*
 * Ian Connors
 * Assignment 1: OOP Review
 * Child class of Fuzzle (This is the one with the lips)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Petra : Fuzzle, ICanLaugh, ICanSleep
{
	private float amountOfLipstick;
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
		Vector3 pos = transform.position;
		while (count < 8)
		{
			transform.Translate(Random.Range(-0.5f, 0.5f), 0, 0);
			yield return new WaitForSeconds(0.1f);
			count++;
		}
		transform.position = pos;
	}
}
