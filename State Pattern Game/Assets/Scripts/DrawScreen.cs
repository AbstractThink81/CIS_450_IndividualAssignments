using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawScreen : MonoBehaviour, Observer
{
    public Text gameText;
    string topText;
    string dots;
    string[] currentBlock = new string[2];
    string[] nextBlock = new string[2];
    string[] nextNextBlock = new string[2];
    bool rightSelectionBox = false;

    private delegate void BitwiseOperation();
    BitwiseOperation currentOperation;

	public bool RightSelectionBox { get => rightSelectionBox; set => rightSelectionBox = value; }

	void Awake()
    {
        topText = "0% - Compiling Shaders (5,409)";
        StartCoroutine(Dots());
        for (int i = 0; i < 2; i++)
		{
            currentBlock[i] = " 0 0 0 0";
		}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rightSelectionBox)
		{
            gameText.text = topText + dots + "\n"
                + " ________        " + "                                       Mistakes: [0/14]" + "\n"
                + "|  " + currentBlock[0] + "  |  " + currentBlock[1] + "\n"
                + "|________|";
		}
		else
		{
            gameText.text = topText + dots + "\n"
                + "                      ________" + "                          Mistakes: [0/14]" + "\n"
                + "    " + currentBlock[0] + "   | " + currentBlock[1] + "   |\n"
                + "                     |________|";
        }
    }
    private IEnumerator Dots()
	{
        while (true)
		{
            yield return new WaitForSeconds(0.5f);
            dots = ".";
            yield return new WaitForSeconds(0.5f);
            dots = "..";
            yield return new WaitForSeconds(0.5f);
            dots = "...";
            yield return new WaitForSeconds(0.5f);
            dots = "....";
        }
    }
    private void Compile()
	{

	}
    private void BitwiseAnd()
	{

	}
    private void InclusiveOr()
    {

    }
    private void ExclusiveOr()
	{

	}

	public void UpdateInputInfo(bool rsb)
	{
        rightSelectionBox = rsb;
	}
}
