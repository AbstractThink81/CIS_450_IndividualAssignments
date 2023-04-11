using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class note : MonoBehaviour
{
	public int speed;
	public bool col = false;
	int i;
	TextMeshProUGUI tmp;
	KeyCode[] codes = {
		KeyCode.A,
		KeyCode.B,
		KeyCode.C,
		KeyCode.D,
		KeyCode.E,
		KeyCode.F,
		KeyCode.G,
		KeyCode.H,
		KeyCode.I,
		KeyCode.J,
		KeyCode.K,
		KeyCode.L,
		KeyCode.M,
		KeyCode.N,
		KeyCode.O,
		KeyCode.P,
		KeyCode.Q,
		KeyCode.R,
		KeyCode.S,
		KeyCode.T,
		KeyCode.U,
		KeyCode.V,
		KeyCode.W,
		KeyCode.X,
		KeyCode.Y,
		KeyCode.Z
	};

	private void Awake()
	{
		tmp = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
		i = Random.Range(0, 26);
		char c = (char)(i + 97);
		string s = c.ToString();
		tmp.text = s;
	}
	private void Update()
	{
		if (col)
		{
			if (Input.GetKeyDown(codes[i]))
				Destroy(gameObject);
			//else if (Input.anyKeyDown)

		}
	}
	void FixedUpdate()
	{
		transform.Translate(-0.1f * speed * transform.right);
		if (transform.position.x < -15)
		{
			Destroy(gameObject);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		col = true;
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		col = false;
	}
}
