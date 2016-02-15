using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class ReadingActions : MonoBehaviour 
{
	private ActionsInput actionsInput;

	private System.Random randomAction = new System.Random();

	private Animator actionsAnim;
	private Animator UIAnim;

	public List<int> readingPattern = new List<int>();

	public int actionsMade = 0;

	public bool isReading = false;

	public float waitTimeBetweenActions = 1.2f;


	public IEnumerator ReadActions()
	{
		isReading = true;

		foreach (int action in readingPattern)
		{
			yield return new WaitForSeconds (waitTimeBetweenActions);

			switch (action)
			{
				case 0:
//					actionsInput.nextButton = 0;
					Debug.Log("Ask for a dance");
					actionsAnim.SetTrigger("Dance");
						break;

				case 1:
//					actionsInput.nextButton = 1;
					Debug.Log("Ask for a nuzzle");
					actionsAnim.SetTrigger("Nuzzle");
						break;

				case 2:
//					actionsInput.nextButton = 2;
					Debug.Log("Ask for a pose");
					actionsAnim.SetTrigger("Pose");
					break;

				case 3:
//					actionsInput.nextButton = 3;
					Debug.Log("Ask for a song");
					actionsAnim.SetTrigger("Sing");
					break;
			}

		}

		isReading = false;
	}


	public bool ReadingCheck()
	{
		return isReading;
	}

	public void StartReading()
	{
		actionsMade = 0;
		readingPattern.Add(randomAction.Next(0,4));
		StartCoroutine(ReadActions());
	}


	// Use this for initialization
	void Awake () 
	{
		actionsInput = GameObject.Find("ActionsCanvas").GetComponent<ActionsInput>();
		UIAnim = GameObject.Find("UI").GetComponent<Animator>();
		UIAnim.SetBool("isReading",isReading);
		actionsAnim = GameObject.Find("ActionsCanvas").GetComponent<Animator>();
//		actionsAnim.SetBool("isDancing", actionsInput.isDancing);
//		actionsAnim.SetBool("isNuzzling", actionsInput.isNuzzling);
//		actionsAnim.SetBool("isPosing", actionsInput.isPosing);
//		actionsAnim.SetBool("isSinging",  actionsInput.isSinging);

	}

	void Start()
	{
		StartReading();
	//	actionsMade = 0;

	}

	// Update is called once per frame
	void Update () 
	{
		ReadingCheck();
	
	}
}
