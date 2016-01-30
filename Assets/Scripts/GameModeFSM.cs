﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameModeFSM : MonoBehaviour 
{
	private SimpleTouchAreaButton touchPanel;
	private SimpleTouchAreaButton start;
	private SimpleTouchAreaButton quitToMain;

	private Animator UIController;



	[SerializeField] public enum GameStates
	{
		MainMenu,
		PlayGame
	}

	[SerializeField] public GameStates currentState;

	Dictionary <GameStates, Action> fsm = new Dictionary <GameStates, Action> ();

	public void SetState (GameStates nextState)
	{
		if (nextState != currentState)
		{
			currentState = nextState;
			Debug.Log ("Switching to " + nextState);
		}
	}
		
	// Use this for initialization
	void Start () 
	{
		touchPanel = GameObject.Find("TouchPanel").GetComponent<SimpleTouchAreaButton>();
		start = GameObject.Find("Start").GetComponent<SimpleTouchAreaButton>();
		quitToMain = GameObject.Find("QuitToMain").GetComponent<SimpleTouchAreaButton>();

		UIController = GameObject.Find("UI").GetComponent<Animator>();


		fsm.Add (GameStates.MainMenu, MainMenuState);
		fsm.Add (GameStates.PlayGame, PlayGameState);

		SetState (GameStates.MainMenu);
	}

	// Update is called once per frame
	void Update () 
	{
		if (fsm[currentState] != null)
		{
			fsm[currentState].Invoke();
		}

	}
		 
////////////////////////////////
/// <summary>
/// 
/// Main Menu Stuff Goes Here
/// 
/// </summary>
///////////////////////////////

	public void MainMenuState ()
	{
		if (start.CanAccessButtonArea())
		{
			UIController.SetTrigger("PlayTriggered");
			SetState(GameStates.PlayGame);
		}
	}

///////////////////////////////////
/// <summary>
/// 
/// Main Gameplay Stuff Goes Here
/// 
/// </summary>
//////////////////////////////////

	public void PlayGameState ()
	{
		if (quitToMain.CanAccessButtonArea())
		{
			UIController.SetTrigger("QuitTriggered");
			SetState(GameStates.MainMenu);
		}
		
	}



}
