using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathItem : MonoBehaviour
{
    private int itemNumber;
    private int direction = 1;
    [SerializeField]private GameObject nextVertex;
    public AnimatedPath pathScript;
    private int nextVertexIndex;
    private int wait = 0;
    //private LevelManager levelManager;
    //private Rigidbody Rigid;
    private int speedDistMultiplier = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        //Rigid = GetComponent<Rigidbody>();
        pathScript = transform.parent.gameObject.GetComponent<AnimatedPath>();
        direction = pathScript.movementDirection;
        
        if (pathScript.movementType != 3)
        {
            itemNumber = transform.GetSiblingIndex() - pathScript.childNumberOfFirstItem;
            nextVertexIndex = pathScript.itemVertexAssignments[itemNumber] + pathScript.movementDirection;
		}
		else
		{
            itemNumber = transform.GetSiblingIndex() - 1;
		}
        //levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();


        if (nextVertexIndex < 0)
		{
            nextVertexIndex = pathScript.childNumberOfFirstItem - 1;
		}
        if (pathScript.movementType != 3)
        {
            nextVertex = transform.parent.GetChild(nextVertexIndex).gameObject;
        }
        else
        {
            nextVertex = pathScript.transform.GetChild(0).GetChild(pathScript.itemVertexAssignments[itemNumber] - 1).gameObject;
        }
        if (!GetComponent<Platform>() && pathScript.itemIsPlatform[itemNumber])
		{
            gameObject.AddComponent<Platform>();
		}
        if (GetComponent<Platform>() && !pathScript.itemIsPlatform[itemNumber])
        {
            Destroy(GetComponent<Platform>());
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (pathScript.isAnimating)
        {
            UpdatePosition(pathScript.speed /** levelManager.worldSpeed */* Time.deltaTime);
            
        }
    }
    private void UpdatePosition(float speed)
    {
        if (direction != pathScript.movementDirection && pathScript.movementType != 3)
        {
            nextVertexIndex += pathScript.movementDirection;
            nextVertex = transform.parent.GetChild(nextVertexIndex).gameObject;
            direction = pathScript.movementDirection;
        }
        if (pathScript.movementType == 3)
		{
            transform.rotation = nextVertex.transform.rotation;
		}
        if (transform.position != nextVertex.transform.position)
        {
            if (wait < 10)
			{
                wait++;
			}
            transform.position = Vector3.MoveTowards(transform.position, nextVertex.transform.position, speed * speedDistMultiplier);
            //if (pathScript.movementType == 3) transform.LookAt(nextVertex.transform);
            //Rigid.AddForce(transform.forward * speed);
        }
        else if (nextVertexIndex + pathScript.movementDirection < pathScript.childNumberOfFirstItem && nextVertexIndex + pathScript.movementDirection > -1 && pathScript.movementType != 3)
        {
            

            nextVertexIndex += pathScript.movementDirection;
            nextVertex = transform.parent.GetChild(nextVertexIndex).gameObject;
            transform.position = Vector3.MoveTowards(transform.position, nextVertex.transform.position, speed * speedDistMultiplier);
            if (wait > 9)
            {
                pathScript.AtVertex(nextVertexIndex - pathScript.movementDirection);
                wait = 0;
            }

        }
        else if (pathScript.movementType != 3)
        {
            
            if (pathScript.movementType == 1 && !pathScript.pathIsOneWay)//if path is of path type
            {
                pathScript.SwitchDirection();
                direction = pathScript.movementDirection;

            }
            if (pathScript.movementType == 2)//if path is a cycle
            {
                if (pathScript.movementDirection == 1)
                {
                    nextVertexIndex = 0;
                }
                else
                {
                    nextVertexIndex = pathScript.childNumberOfFirstItem - 1;
                }
                nextVertex = transform.parent.GetChild(nextVertexIndex).gameObject;
            }
            transform.position = Vector3.MoveTowards(transform.position, nextVertex.transform.position, speed);
            if (wait > 9)
            {
                pathScript.AtVertex(nextVertexIndex - pathScript.movementDirection);
                wait = 0;
            }
            
        }
    }
}
