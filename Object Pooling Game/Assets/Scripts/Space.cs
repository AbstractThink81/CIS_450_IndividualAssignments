using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Space : MonoBehaviour
{
	public int tileIndex;
    public void OnClick()
	{
		GameObject tile = ObjectPooler.instance.SpawnFromPool("tile", gameObject.transform.localPosition, Quaternion.identity);
		tile.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.instance.characters[tileIndex].ToString();
		tile.GetComponentInChildren<Tile>().tileSpace = this;
		GameObject[] objectList = GameObject.FindGameObjectsWithTag("Tile");

		foreach (GameObject go in objectList)
		{
			if (go == tile)
				continue;
			Debug.Log("Checking Tiles");
			StartCoroutine(WaitDisappear(go.GetComponent<Tile>().tileSpace.gameObject, go, tile, go.GetComponentInChildren<TextMeshProUGUI>().text.ToCharArray()[0] == GameManager.instance.characters[tileIndex]));
		}
	}
	private IEnumerator WaitDisappear(GameObject goSpace, GameObject go, GameObject goNew, bool correct)
	{
		if (correct)
		{
			goSpace.GetComponentInChildren<Image>().color = Color.gray;
			gameObject.GetComponentInChildren<Image>().color = Color.gray;
		}
		GameObject[] spaceList = GameObject.FindGameObjectsWithTag("Space");
		foreach (GameObject g in spaceList)
		{
			g.GetComponentInChildren<Button>().enabled = false;
		}
		yield return new WaitForSeconds(0.5f);

		ObjectPooler.instance.ReturnObjectToPool("tile", go);
		ObjectPooler.instance.ReturnObjectToPool("tile", goNew);
		foreach (GameObject g in spaceList)
		{
			g.GetComponentInChildren<Button>().enabled = true;
		}
		if (correct)
		{
			GameManager.instance.AddScore(2);
			ObjectPooler.instance.ReturnObjectToPool("space", goSpace);
			ObjectPooler.instance.ReturnObjectToPool("space", gameObject);
		}
	}
}
