using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleKeyPress
{
    private string keyCode;
    public string KeyCode { get => keyCode; set => keyCode = value; }
    private NoteManager noteManager;
	public SingleKeyPress(string key)
	{
		noteManager = GameObject.FindGameObjectWithTag("NoteManager").GetComponent<NoteManager>();
		keyCode = key;
	}
    public void Execute()
	{
		noteManager.PressNote(keyCode);
	}
}
