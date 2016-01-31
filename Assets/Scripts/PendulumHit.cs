using UnityEngine;
using System.Collections;

public class PendulumHit : MonoBehaviour 
{
	public SimpleTouchAreaButton touchPanel;

	private BoxCollider2D greatHitCollider;
	private BoxCollider2D perfectHitCollider;
	private BoxCollider2D pendulumCollider;

	public Animator metronomeController;

	private bool isPlayerTouching;

	// Use this for initialization
	void Start () 
	{
		touchPanel = GameObject.Find("TouchPanel").GetComponent<SimpleTouchAreaButton>();

		greatHitCollider = GameObject.Find("GreatHit").GetComponent<BoxCollider2D>();
		perfectHitCollider = GameObject.Find("PerfectHit").GetComponent<BoxCollider2D>();
		pendulumCollider = GameObject.Find("Pendulum").GetComponent<BoxCollider2D>();

		metronomeController = GameObject.Find("Metronome").GetComponent<Animator>();
	}

	public void PendulumHitCheck()
	{
		if (isPlayerTouching)
		{
			metronomeController.speed = 0f;

			if (pendulumCollider.IsTouching(greatHitCollider))
			{
				if (pendulumCollider.IsTouching(perfectHitCollider))
				{
					Debug.Log("P E R F E C T    M O V E ! ! !");
				}

				else
				{
					Debug.Log("GREAT MOVE!");
				}
			}

			else
			{
				Debug.Log("You'll get there..."); 
			}
		}

		else
		{
			metronomeController.speed = 1f;		


		}
	}

	void Update () 
	{
		PendulumHitCheck();

		isPlayerTouching = touchPanel.CanAccessButtonArea();

	}
}
