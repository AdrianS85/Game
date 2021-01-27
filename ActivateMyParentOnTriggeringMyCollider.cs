using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMyParentOnTriggeringMyCollider : MonoBehaviour {

	public scriptableObjectSpawner so;

	public MonoBehaviour componentToActivate;



	private string whoCanActivateMe {get; set;}
	void Awake(){
		whoCanActivateMe = so.heroObjectName;
		componentToActivate = GetComponentInParent<EatMeBehavior>();
	}



	public void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == whoCanActivateMe)
		{
			componentToActivate.enabled = true;
		}
	}



	public void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name == whoCanActivateMe)
		{
			componentToActivate.enabled = false;
		}
	}

}
