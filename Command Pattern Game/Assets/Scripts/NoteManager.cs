using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager: MonoBehaviour
{
	//Note: notes are spawned by SongManager 


	static float timeWindow;
	private void Awake()
	{
		timeWindow = 2 - SongManager.bps;
	}
	private Queue<SingleNote> pressableNotes = new Queue<SingleNote>();
    public void AddNoteToPressable(SingleNote item)
	{
		pressableNotes.Enqueue(item);
		Debug.Log("Added to Queue");
		StartCoroutine(PressTimeWindow());
	}
	public void PressNote(string keyCode)
	{
		pressableNotes.Peek().KeyPress(keyCode);
		pressableNotes.Dequeue();
		Debug.Log("Removed from Queue");
	}
	private IEnumerator PressTimeWindow()
	{
		yield return new WaitForSeconds(timeWindow);
		pressableNotes.Dequeue();
		Debug.Log("Removed from Queue");

	}
}
