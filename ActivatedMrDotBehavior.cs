using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedMrDotBehavior : MonoBehaviour, IActivateBehavior {

	public string whoCanActivateMe {get; set;}
	void Awake(){
		whoCanActivateMe = "MrHero";
	}

// How to merge this and similar classes in sensible template?
	public void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == whoCanActivateMe)
		{
			if(gameObject.GetComponent<V_EatMeBehavior>() == null){
				gameObject.AddComponent<V_EatMeBehavior>();
			}
		}
	}

	public void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name == whoCanActivateMe)
		{
			if(gameObject.GetComponent<V_EatMeBehavior>() != null){
				Destroy(gameObject.GetComponent<V_EatMeBehavior>());
			}
		}
	}

}
