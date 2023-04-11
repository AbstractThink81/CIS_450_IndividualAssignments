using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongManager : MonoBehaviour
{
    public GameObject n1;
    public AudioSource audioSource;
    public static int bpm = 100;
    public static float bps = 5f / 3f;
    private static TextMeshProUGUI comboText;
    public static int combo = 0;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(spawnNotes());
        comboText = GameObject.FindGameObjectWithTag("ComboText").GetComponent<TextMeshProUGUI>();
        combo = 0;
    }

    public static void UpdateUI()
    {
        comboText.text = "Combo: " + combo.ToString();
    }
    private IEnumerator spawnNotes()
	{
        yield return new WaitForSeconds(2f);
        audioSource.Play();

        yield return new WaitForSeconds(0.3f);
        while (true)
		{
            yield return new WaitForSeconds(0.6f);
            string path = InputManager.mainKeys[Random.Range(0, InputManager.mainKeys.Length)][Random.Range(0, 10)] + "Key";
            if (path == ".Key") path = "periodKey";
            if (path == "/Key") path = "slashKey";
            Instantiate((GameObject)Resources.Load(path), GameObject.FindGameObjectWithTag("Canvas").transform);
        }
	}
    private IEnumerator Part1()
	{

	}
    private IEnumerator Chorus1()
	{

	}
    private IEnumerator Part2()
    {

    }
    private IEnumerator Chorus2()
    {

    }
}
