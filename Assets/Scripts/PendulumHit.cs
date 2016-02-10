using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PendulumHit : MonoBehaviour 
{

	private Button danceButton;

	public BoxCollider2D greatHitCollider;
	public BoxCollider2D perfectHitCollider;
	public BoxCollider2D pendulumCollider;

	public Animator metronomeController;

	public string areaHit;

	private bool isPlayerTouching;

	private ActionsInput actionsInput;
	private ReadingActions readingActions;

	// Use this for initialization
	void Start () 
	{
		danceButton = GameObject.Find("ButtonDance").GetComponent<Button>();

		greatHitCollider = GameObject.Find("GreatHit").GetComponent<BoxCollider2D>();
		perfectHitCollider = GameObject.Find("PerfectHit").GetComponent<BoxCollider2D>();
		pendulumCollider = GameObject.Find("Pendulum").GetComponent<BoxCollider2D>();
	}

	public string AreaHit()
	{
		return areaHit;	
	}

	void Update () 
	{
		AreaHit();
		metronomeController.speed = 1f;
	
	}
}
