using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedMrKeyBehavior : MonoBehaviour, IActivateBehavior {

    public string whoCanActivateMe {get; set;}
	void Awake(){
		whoCanActivateMe = "MrHero";
	}

// How to merge this and similar classes in sensible template?
	public void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == whoCanActivateMe)
		{
			if(gameObject.GetComponent<TakeMeBehavior>() == null){
				gameObject.AddComponent<TakeMeBehavior>();
			}
		}
	}

	public void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name == whoCanActivateMe)
		{
			if(gameObject.GetComponent<TakeMeBehavior>() != null){
				Destroy(gameObject.GetComponent<TakeMeBehavior>());
			}
		}
	}

}
