using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedMrDotBehavior : MonoBehaviour, IActivateBehavior {

	public string whoCanActivateMe {get; set;}
	List<Comp>



	void Awake(){
		whoCanActivateMe = "MrHero";
	}

// Implement this as a dynamic factory? Template?
	public void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == whoCanActivateMe)
		{
			if(gameObject.GetComponent<EatMeBehavior>() == null){
				gameObject.AddComponent<EatMeBehavior>();
			}

		}
	}

	public void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name == whoCanActivateMe)
		{
			Debug.Log(other.gameObject.name);
			if(gameObject.GetComponent<EatMeBehavior>() != null){
				Destroy(gameObject.GetComponent<EatMeBehavior>());
			}

		}
	}


}
