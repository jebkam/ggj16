using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class ActionsInput : MonoBehaviour 
{
	//public int nextButton;

	/// <summary>
	/// 
	/// The player score will be as follows:
	/// 
	/// score = (basePoints * correctActionMultiplier) * timingMultiplier;
	/// 
	/// </summary>
	public float playerHitScore;
	public float playerTotalScore;
	public float maxScore;
	public float basePoints;
	public int correctActionMultiplier;
	public float timingMultiplier;
	public float perfectTiming;
	public float greatTiming;
	public float niceTiming;

	private ReadingActions readingActions;
	private PendulumHit pendulumHit;
	private Text scoreText;

	public void TestResults(int correctButton)
	{
		if(readingActions.ReadingCheck())
		{
			return;
		}
			
		if ((readingActions.readingPattern[readingActions.actionsMade] == correctButton))
		{

			if (pendulumHit.pendulumCollider.IsTouching(pendulumHit.greatHitCollider))
			{
				timingMultiplier = greatTiming;
				playerTotalScore = playerTotalScore + playerHitScore;
				pendulumHit.areaHit = "Great";
				Debug.Log("GREAT MOVE!");
			}

			if (pendulumHit.pendulumCollider.IsTouching(pendulumHit.perfectHitCollider))
			{
				timingMultiplier = perfectTiming;
				playerTotalScore = playerTotalScore + playerHitScore;
				pendulumHit.areaHit = "Perfect";
				Debug.Log("P E R F E C T    M O V E ! ! ! ");
			}

			else
			{
				timingMultiplier = niceTiming;
				pendulumHit.areaHit = "OK";
				Debug.Log("Nice move!"); 
			}

			playerTotalScore = playerTotalScore + playerHitScore;
			Debug.Log ("Correct! It Worked!");
			readingActions.actionsMade++;
			CheckForMultiplier();
			Debug.Log(readingActions.actionsMade);
		}

		else
		{
			Debug.Log("Incorrect! Final Score: " + readingActions.readingPattern.Count.ToString());
			readingActions.actionsMade = 0;
			readingActions.readingPattern = new List<int>();
			Debug.Log("Starting Again...");
			correctActionMultiplier = 1;
			StartCoroutine(readingActions.ReadActions());
		}

		if(readingActions.actionsMade >= readingActions.readingPattern.Count)
		{
			Debug.Log("Get Ready");
			readingActions.StartReading();
		}



	}
		

	// Use this for initialization
	void Start () 
	{
		readingActions = GameObject.Find("ReadingBird").GetComponent<ReadingActions>();
		pendulumHit = GameObject.Find("Pendulum").GetComponent<PendulumHit>();
		scoreText = GameObject.Find("Score").GetComponent<Text>();
	}

	public void CheckForMultiplier()
	{


		if (readingActions.readingPattern.Count >= 4)
		{
			correctActionMultiplier = 2;
		}

		if (readingActions.readingPattern.Count >= 8)
		{
			correctActionMultiplier = 3;
		}

		if (readingActions.readingPattern.Count >= 12)
		{
			correctActionMultiplier = 4;
		}

		else
		{
			correctActionMultiplier = 1;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		playerHitScore = (basePoints * correctActionMultiplier) * timingMultiplier;
		scoreText.text = "Score: " + playerTotalScore.ToString();

		if (playerTotalScore >= maxScore)
		{
			scoreText.text = "You Win!";
			StopCoroutine(readingActions.ReadActions());
		}



	}
}
