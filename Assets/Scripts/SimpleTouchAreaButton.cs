using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SimpleTouchAreaButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	
	private bool touched;
	private int pointerID;
	private bool canAccessButtonArea; 
	
	void Awake () {
		touched = false;
		canAccessButtonArea = false;
	}
	
	public void OnPointerDown (PointerEventData data) {
		if (!touched) {
			touched = true;
			pointerID = data.pointerId;
			canAccessButtonArea = true;
		}
	}
	
	public void OnPointerUp (PointerEventData data) {
		if (data.pointerId == pointerID) {
			canAccessButtonArea = false;
			touched = false;
		}
	}
	
	public bool CanAccessButtonArea () {
		return canAccessButtonArea;
	}
	
}
