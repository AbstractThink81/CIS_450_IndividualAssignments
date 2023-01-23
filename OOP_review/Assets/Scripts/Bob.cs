/*
 * Ian Connors
 * Assignment 1: OOP Review
 * Child class of Fuzzle (This is the one with the smile)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : Fuzzle, ICanLaugh, ICanSleep
{
	private float excitement;
	public Sprite sleepSprite;
	public Sprite awakeSprite;
	private Vector3 pos;
	private void OnEnable()
	{
		pos = transform.position;
	}
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
		while (count < 20)
		{
			transform.Translate(0, Random.Range(-3f, 3f), 0);
			yield return new WaitForSeconds(0.05f);
			count++;
		}
		transform.position = pos;
	}
}
