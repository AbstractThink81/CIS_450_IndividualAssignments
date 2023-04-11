using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    int maxXPosition;
    int minXPosition;
    int maxYPosition;
    int minYPosition;
    int xPosition;
    int yPosition;

    bool rightSelectionBox = false;

    private List<Observer> observers = new List<Observer>();
    // Start is called before the first frame update
    void Awake()
    {
        observers.Add(GameObject.FindGameObjectWithTag("Canvas").GetComponent<Observer>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && yPosition > minYPosition)
        {
            yPosition--;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && rightSelectionBox)
        {
            rightSelectionBox = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !rightSelectionBox)
        {
            rightSelectionBox = true;
        }
        foreach (Observer o in observers)
		{
            o.UpdateInputInfo(rightSelectionBox);
		}
    }
}
