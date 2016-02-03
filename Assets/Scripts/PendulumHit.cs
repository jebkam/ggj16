using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PendulumHit : MonoBehaviour 
{
	[HideInInspector] public SimpleTouchAreaButton touchPanel;

	private BoxCollider2D greatHitCollider;
	private BoxCollider2D perfectHitCollider;
	private BoxCollider2D pendulumCollider;

	public Animator metronomeController;

	private string areaHit;

	private bool isPlayerTouching;

	// Use this for initialization
	void Start () 
	{
		touchPanel = GameObject.Find("TouchPanel").GetComponent<SimpleTouchAreaButton>();

		greatHitCollider = GameObject.Find("GreatHit").GetComponent<BoxCollider2D>();
		perfectHitCollider = GameObject.Find("PerfectHit").GetComponent<BoxCollider2D>();
		pendulumCollider = GameObject.Find("Pendulum").GetComponent<BoxCollider2D>();

//		metronomeController = GameObject.Find("Metronome").GetComponent<Animator>();
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
					areaHit = "Perfect";
					Debug.Log("P E R F E C T    M O V E ! ! !");
				}

				else
				{
					areaHit = "Great";
					Debug.Log("GREAT MOVE!");
				}
			}

			else
			{
				areaHit = "OK";
				Debug.Log("You'll get there..."); 
			}
		}

		else
		{
			areaHit = "Nothing";
			metronomeController.speed = 1f;		


		}
	}

	public string AreaHit()
	{
		return areaHit;	
	}

	void Update () 
	{
		PendulumHitCheck();
		AreaHit();

		isPlayerTouching = touchPanel.CanAccessButtonArea();

	}
}
