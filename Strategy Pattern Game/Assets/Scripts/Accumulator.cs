/*
 * Ian Connors
 * Accumulator.cs
 * CIS 450 Assignment 2
 * Keeps track of the changing color of the Accumulator and manages the score when boxes collide with it
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Accumulator : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public List<Material> materials = new();
    private MeshRenderer meshRenderer;
    public int color; //0 = red; 1 = yellow; 2 = green; 4 = blue
    private static string[] colors = { "Red", "Yellow", "Green", "Blue" };
    public GameManager gameManager;

    void Start()
    {
        score = 0;
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(PeriodicColorChange());
    }

    IEnumerator PeriodicColorChange()
	{
        while (true)
        {
            int newColor = Random.Range(0, materials.Count);
            for (int i = 25; i >= 0; i--)
			{
                yield return new WaitForSeconds(1f);
                if (i == 0)
                {
                    timerText.text = "";
				}
				else
				{
                    timerText.text = colors[newColor] + " in " + i.ToString();
                }
            }
            color = newColor;
            meshRenderer.material = materials[color];

		}
	}
	private void OnTriggerEnter(Collider other)
	{
        if (other.GetComponent<PathItem>())
		{
            if (other.GetComponent<PathItem>().variety.GetVarietyIndex() == color)
			{
                score += other.GetComponent<PathItem>().variety.pointValue();
			}
			else
			{
                score -= other.GetComponent<PathItem>().variety.pointValue();
            }
            
            if (score < 0) gameManager.GameLost();
            if (score >= 2000) gameManager.GameWon();
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
        }
    }
}
