/*
* Ian Connors
* KanjiComposite.cs
* CIS 450 - Assignment 12
* Contains information on the two kanji components that make up a larger kanji
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiComposite : Kanji
{
	private List<Kanji> components;
	public void AddComponents(Kanji component0, Kanji component1)
	{
		components = new List<Kanji>();
		components.Add(component0);
		components.Add(component1);
	}
	public Kanji[] GetComponents()
	{
		Kanji[] array = new Kanji[2] { components[0], components[1] };
		return array;
	}
	public override string ListComponents()
	{
		Kanji[] array = GetComponents();
		if (KanjiDictionary.kanjiMeanings.TryGetValue(character, out string meaning))
			return character + " " + meaning + "\n" + array[0].ListComponents() + array[1].ListComponents();
		else
			return character + " *no meaning*" + "\n" + array[0].ListComponents() + array[1].ListComponents();
	}
}
