using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class ReadingActions : MonoBehaviour 
{
	private ActionsInput actionsInput;

	public int actionsMade = 0;

	private Animator actionsAnim;

	public List<int> readingPattern = new List<int>();

	private System.Random randomAction = new System.Random();

	public bool isReading = false;

	private Animator UIAnim;

	public IEnumerator ReadActions()
	{
		isReading = true;

		foreach (int action in readingPattern)
		{
			switch (action)
			{
				case 0:
					Debug.Log("Ask for a dance");
					actionsAnim.SetTrigger("Dance");
				//	yield return new WaitForSeconds(2f);
						break;

				case 1:
					Debug.Log("Ask for a nuzzle");
					actionsAnim.SetTrigger("Nuzzle");

				//	yield return new WaitForSeconds (2f);
					break;

				case 2:
					Debug.Log("Ask for a pose");
					actionsAnim.SetTrigger("Pose");
	//				yield return new WaitForSeconds (2f);
					break;

				case 3:
					Debug.Log("Ask for a song");
					actionsAnim.SetTrigger("Sing");
	//				yield return new WaitForSeconds (2f);
					break;
			}

			yield return new WaitForSeconds (2f);
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
		actionsAnim.SetBool("isDancing", actionsInput.isDancing);
		actionsAnim.SetBool("isNuzzling", actionsInput.isNuzzling);
		actionsAnim.SetBool("isPosing", actionsInput.isPosing);
		actionsAnim.SetBool("isSinging",  actionsInput.isSinging);

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
