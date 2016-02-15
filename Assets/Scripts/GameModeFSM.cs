using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameModeFSM : MonoBehaviour 
{
	
	//public AudioSource tapSound;



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
	void Awake () 
	{
		////
	//	tapSound = GameObject.Find("tapSound").GetComponent<AudioSource>();
		////

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
		SetState(GameStates.MainMenu);

		print (currentState);

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
		SetState(GameStates.PlayGame);

		print(currentState);

		
	}



}
