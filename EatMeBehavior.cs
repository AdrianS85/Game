using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //

public class EatMeBehavior : MonoBehaviour {

	public delegate void AteMe(int change);
	public static event AteMe AteMeEvent;

	public int howTasty = 1;

	public void OnMouseOver()
	    {
	        if( Input.GetMouseButtonDown(0) ){
				Debug.Log("EatMeBehavior: Nom " + howTasty.ToString());
				AteMeEvent(howTasty);
				Destroy(gameObject);
				}
	    }
}
