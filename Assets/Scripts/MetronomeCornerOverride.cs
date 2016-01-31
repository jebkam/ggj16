using UnityEngine;
using System.Collections;

public class MetronomeCornerOverride : MonoBehaviour 
{
	public Animator Metronome;

	public GameObject LeftCorner;
	public GameObject RightCorner;

	private float leftCornerX;
	private float rightCornerX;


	// Use this for initialization
	void Awake () 
	{
		leftCornerX = LeftCorner.transform.position.x;
		rightCornerX = RightCorner.transform.position.x;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
