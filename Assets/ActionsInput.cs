using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class ActionsInput : MonoBehaviour 
{
	private Button danceButton;
	private Button nuzzleButton;
	private Button poseButton;
	private Button singButton;


	private ReadingActions readingActions;

	public int actionButton;

	public bool isDancing;
	public bool isNuzzling;
	public bool isPosing;
	public bool isSinging;

/*	public void ActionInputCheck()
	{
		/////////
		/// Ok, So the thing here is that you're doing something Backwards.
		/// dance.onClick() is the function you call... (no se. tired)
		////////
		if (danceButton.onClick)
		{
			actionButton = 0;
			Debug.Log("actionButton = 0 = Dance");
//			isDancing = true;
//			isDancing = false;

		}

		if (nuzzleButton.onClick)
		{
			actionButton = 1;
			Debug.Log("actionButton = 1 = Nuzzle");
//			isNuzzling = true;
//			isNuzzling = false;
		}

		if (poseButton.onClick)
		{
			actionButton = 2;
			Debug.Log("actionButton = 2 = Pose");
//			isPosing = true;
//			isPosing = false;
		}

		if (singButton.onClick)
		{
			actionButton = 3;
			Debug.Log("actionButton = 3 = Sing");
//			isSinging = true;
//			isSinging = false;
		}

/*		else
		{
			actionButton = 4;
			Debug.Log("actionButton = 4 = Nothing");
			isDancing = false;
			isNuzzling = false;
			isPosing = false;
			isSinging = false;


		}
	
	}

	public void ActionInputTest()
	{
		if (actionButton == 0)
		{
			Debug.Log("Touched dance");
			TestResults(0);
			actionButton = 4;
		}

		if (actionButton == 1)
		{
			Debug.Log("Touched nuzzle");
			TestResults(1);
			actionButton = 4;
		}

		if (actionButton == 2)
		{
			Debug.Log("Touched pose");
			TestResults(2);
			actionButton = 4;
		}

		if (actionButton == 3)
		{
			Debug.Log("Touched sing");
			TestResults(3);
			actionButton = 4;
		}
	}*/


	public void TestResults(int actionButton)
	{
		if(readingActions.ReadingCheck())
		{
			return;
		}

		if (readingActions.readingPattern[readingActions.actionsMade] == actionButton)
		{
			Debug.Log ("Correct!");
			readingActions.actionsMade++;
			Debug.Log(readingActions.actionsMade);
		}

		else
		{
			Debug.Log("Incorrect! Final Score: " + readingActions.readingPattern.Count.ToString());
			readingActions.actionsMade = 0;
			readingActions.readingPattern = new List<int>();
			Debug.Log("Starting Again...");
//			WaitForSeconds (2);
			StartCoroutine(readingActions.ReadActions());
		}

		if(readingActions.actionsMade >= readingActions.readingPattern.Count)
		{
			Debug.Log("Get Ready");
//			WaitForSeconds(2);
			readingActions.StartReading();
		}
	}
		

	// Use this for initialization
	void Start () 
	{
		readingActions = GameObject.Find("ReadingBird").GetComponent<ReadingActions>();

		danceButton = GameObject.Find("ButtonDance").GetComponent<Button>();
		nuzzleButton = GameObject.Find("ButtonNuzzle").GetComponent<Button>();
		poseButton = GameObject.Find("ButtonPose").GetComponent<Button>();
		singButton = GameObject.Find("ButtonSing").GetComponent<Button>();
	
	}


	// Update is called once per frame
	void Update () 
	{
//		ActionInputCheck();
//		ActionInputTest();
	}
}
