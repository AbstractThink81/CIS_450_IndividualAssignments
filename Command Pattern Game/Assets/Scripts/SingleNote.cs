using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SingleNote : MonoBehaviour
{
    //Vector3 hitPositon;
    static float hitTime = 1.2f;
    float time;
    //float speed;
    public TextMeshProUGUI text;
    public string character; //the display character
    public string key; //position of the key relative to a single row on the keyboard
    public string keyCode; //the key code that corresponds to the otehr scripts
    NoteManager noteManager;
    private bool queued = false;
    // Start is called before the first frame update
    void Awake()
    {
        time = 0.01f;
        GetComponent<Animator>().Play(key);
    }
	private void Start()
	{
        text.text = character;
        noteManager = GameObject.FindGameObjectWithTag("NoteManager").GetComponent<NoteManager>();
    }

	// Update is called once per frame
	private void Update()
	{
        time += Time.deltaTime;
        if (time >= hitTime * SongManager.bps / 2 && !queued)
		{
            noteManager.AddNoteToPressable(this);
            queued = true;
		}
        //text.text = time.ToString("#.00");
    }
	void FixedUpdate()
    {
        if (transform.localPosition.y < -209)
		{
            Destroy(gameObject);
		}
        //transform.Translate(speed * (hitPositon - transform.position) / (hitTime * Time.deltaTime));
    }
    public void KeyPress(string code)
	{
        if (code == keyCode)
		{
            Debug.Log("Correct!");
            SongManager.combo++;
            SongManager.UpdateUI();
		}
		else
		{
            Debug.Log("Incorrect!");
            SongManager.combo = 0;
            SongManager.UpdateUI();
        }

        Destroy(gameObject);
    }
}
