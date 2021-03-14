using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedMrGateBehavior : MonoBehaviour, IActivateBehavior
{
    public string whoCanActivateMe {get; set;}
	void Awake(){
		whoCanActivateMe = "MrHero";
	}

// How to merge this and similar classes in sensible template?
	public void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == whoCanActivateMe)
		{
			if(gameObject.GetComponent<UseItemOnMeBehavior>() == null){
				gameObject.AddComponent<UseItemOnMeBehavior>();
			}
		}
	}

	public void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name == whoCanActivateMe)
		{
			if(gameObject.GetComponent<UseItemOnMeBehavior>() != null){
				Destroy(gameObject.GetComponent<UseItemOnMeBehavior>());
			}
		}
	}
}
