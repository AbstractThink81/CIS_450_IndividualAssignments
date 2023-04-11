using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static string[] numberKeys = {
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "0"
    };
    public static string[] topRowKeys = {
        "q",
        "w",
        "e",
        "r",
        "t",
        "y",
        "u",
        "i",
        "o",
        "p"
    };
    public static string[] homeRowKeys = {
        "a",
        "s",
        "d",
        "f",
        "g",
        "h",
        "j",
        "k",
        "l",
        ";"
    };
    public static string[] bottomRowKeys = {
        "z",
        "x",
        "c",
        "v",
        "b",
        "n",
        "m",
        ",",
        ".",
        "/"
    };
    public static string[][] mainKeys =
    {
        topRowKeys,
        homeRowKeys,
        bottomRowKeys
    };
    public static List<string> usedKeys = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
		{
            foreach (string s in mainKeys[i])
            {
                usedKeys.Add(s);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            Debug.Log("KeyPressed");
            foreach (string s in usedKeys)
			{
                if (Input.GetKeyDown(s))
				{
                    SingleKeyPress skp = new SingleKeyPress(s);
                    skp.Execute();
                }
			}
		}
    }
}
