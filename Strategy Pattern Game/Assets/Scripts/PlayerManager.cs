/*
 * Ian Connors
 * PlayerManager.cs
 * CIS 450 Assignment 2
 * Manages the held cube animations and color switching of cubes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] heldCube;
    public int activeCube;
    public List<Material> materials;
    private int[] variety = new int[4];

    // Update is called once per frame
    void Update()
    {
        heldCube[activeCube].transform.Rotate(0, -120 * Time.deltaTime, 0);
        if (Input.GetKeyDown(KeyCode.Mouse0))
		{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("HIT!");
                if (hit.collider.gameObject.GetComponent<PathItem>())
                {
                    int temp = hit.collider.gameObject.GetComponent<Variety>().GetVarietyIndex();
                    switch (variety[activeCube])
                    {
                        case 0:
                            Destroy(hit.collider.gameObject.GetComponent<Variety>());
                            hit.collider.gameObject.AddComponent<Red>();
                            break;
                        case 1:
                            Destroy(hit.collider.gameObject.GetComponent<Variety>());
                            hit.collider.gameObject.AddComponent<Yellow>();
                            break;
                        case 2:
                            Destroy(hit.collider.gameObject.GetComponent<Variety>());
                            hit.collider.gameObject.AddComponent<Green>();
                            break;
                        case 3:
                            Destroy(hit.collider.gameObject.GetComponent<Variety>());
                            hit.collider.gameObject.AddComponent<Blue>();
                            break;
                        case 4:
                            Destroy(hit.collider.gameObject.GetComponent<Variety>());
                            hit.collider.gameObject.AddComponent<Bomb>();
                            break;
                    }
                    SwitchColor(temp);
                }
            }
        }
    }
    public void SwitchColor(int color)
	{
        heldCube[activeCube].GetComponent<MeshRenderer>().material = materials[color];
        variety[activeCube] = color;
	}
    public void SetActiveCube(int num)
	{
        activeCube = num;
	}
}
