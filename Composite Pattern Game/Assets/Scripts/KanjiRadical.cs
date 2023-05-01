/*
* Ian Connors
* KanjiRadical.cs
* CIS 450 - Assignment 12
* Contains information for a kanji radical
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiRadical : Kanji
{
	public override string ListComponents()
	{
		if (KanjiDictionary.kanjiMeanings.TryGetValue(character, out string meaning))
			return character + " " + meaning + "\n";
		else
			return character + " *no meaning*" + "\n";
	}
}
