using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ReadingMoves : MonoBehaviour 
{
	public int onReadingList = 0;

	public List<int> readingPattern = new List<int>();

	private System.Random nextMove = new System.Random();

	public bool isReading = false;

	private Animator UIAnim;

	public void ReadMoves()
	{
		isReading = true;
		
	}

	// Use this for initialization
	void Awake () 
	{
		UIAnim = GameObject.Find("UI").GetComponent<Animator>();
		UIAnim.SetBool("isReading",isReading);

	}

	void Start()
	{
		readingPattern.Add(nextMove.Next(0,4));

	}

	// Update is called once per frame
	void Update () {

	
	}
}
