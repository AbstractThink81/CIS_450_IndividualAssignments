using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatedPath : MonoBehaviour
{
	public int movementType = 0;
	public float speed = 1;
	public int movementDirection = 1;
	public bool animateOnAwake = false;
	public bool verticesAreVisible = true;
	public bool vertexVisibility = true;
	public bool pathIsVisible = true;
	public bool pathIsOneWay = false;
	public int numberOfVertices = 0;
	public int vertexCounter = 0;
	public int numberOfItems = 0;
	public int childNumberOfFirstItem = 0;
	public int numberOfEvents = 0;
	public string[] movementTypes = { "none", "path", "cycle", "circle" };
	public string[] eventCondition = { "none", "onCollisionBegin", "onCollisionEnd", "onNumberOfCollisions", "atVertex" };

	public string[] eventOption = { "none", "waitForSeconds", "moveItemToVertex", "SwitchDirection",
		"stopPathAnimation", "startPathAnimation", "stopStartPathAnimation",
		"stopPlatformAnimations", "startPlatformAnimations", "stopStartPlatformAnimations" };

	public List<int> eventConditions = new List<int>();
	public List<int> eventConditionParameters = new List<int>();
	public List<int> numberOfSteps = new List<int>();

	public List<int> eventStep0 = new List<int>();
	public List<int> eventStep1 = new List<int>();
	public List<int> eventStep2 = new List<int>();
	
	public List<int> eventStep0Parameters = new List<int>();
	public List<int> eventStep0Parameters1 = new List<int>();

	public List<int> eventStep1Parameters = new List<int>();
	public List<int> eventStep1Parameters1 = new List<int>();

	public List<int> eventStep2Parameters = new List<int>();
	public List<int> eventStep2Parameters1 = new List<int>();

	public List<List<int>> events = new List<List<int>>();
	public List<List<int>> eventParameters = new List<List<int>>();
	public List<List<int>> eventParameters1 = new List<List<int>>();

	public List<GameObject> Vertices = new List<GameObject>();
	public List<GameObject> Items = new List<GameObject>();
	public List<int> itemVertexAssignments = new List<int>();
	public List<bool> itemIsPlatform = new List<bool>();
	public int itemVertexAssignmentCounter = 0;
	public int itemIsPlatformCounter = 0;
	public LineRenderer Lr = null;
	public bool isAnimating = false;
	public bool itemsAreAnimating = false;
	public bool shareCollision = false;
	public GameObject CollisionParent;
	public int collisionNumber = 0;

	private void Awake()
	{
		if (animateOnAwake)
		{
			StartPathAnimation();
		}
		if (speed < 0)
		{
			SwitchDirection();
			speed *= -1;
		}
		events.Add(eventStep0);
		events.Add(eventStep1);
		events.Add(eventStep2);

		eventParameters.Add(eventStep0Parameters);
		eventParameters.Add(eventStep1Parameters);
		eventParameters.Add(eventStep2Parameters);

		eventParameters1.Add(eventStep0Parameters1);
		eventParameters1.Add(eventStep1Parameters1);
		eventParameters1.Add(eventStep2Parameters1);
	}

	private void MoveToVertex(int itemNumber, int vertexNumber)
	{

	}
	private void StopPathAnimation()
	{
		isAnimating = false;
	}
	private void StartPathAnimation()
	{
		isAnimating = true;
	}
	private void StopStartPathAnimation()
	{
		if (isAnimating)
		{
			StopPathAnimation();
		}
		else
		{
			StartPathAnimation();
		}
	}
	private void StopItemAnimations()
	{

	}
	private void StartItemAnimations()
	{

	}
	private void StopStartItemAnimations()
	{
		if (itemsAreAnimating)
		{
			StopPathAnimation();
		}
		else
		{
			//StartPathAnimation();
		}
	}
	public void SwitchDirection()
	{
		movementDirection *= -1;
	}

	public void CollisionBegin()
	{
		CollisionNumber(++collisionNumber);
		//StartCoroutine(CallEvents(1, 0));
		//OnCollisionBegin?.Invoke();
	}
	public void CollisionEnd()
	{
		CollisionNumber(--collisionNumber);
		//StartCoroutine(CallEvents(2, 0));
		//OnCollisionEnd?.Invoke();
	}
	public void CollisionNumber(int n)
	{
		//StartCoroutine(CallEvents(3, n));
	}
	public void AtVertex(int n) {
		//StartCoroutine(CallEvents(4, n));
	}
	//private Coroutine eventRoutine(int[] eve)
	//{
	//	for (int i = 0; i < eve.Length; i++)
	//	{

	//	}

	//}
	
}
