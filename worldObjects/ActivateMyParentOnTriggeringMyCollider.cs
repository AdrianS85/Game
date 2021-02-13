using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMyParentOnTriggeringMyCollider : MonoBehaviour {
	// Needs collider with trigger that is further from camera than actual object. Needs to be put into object with its own triggering colider, so that the actual object can have its own, standard colider 

	public scriptableObjectSpawner so;
	public GameObject myParent;
	//public MonoBehaviour componentToActivate;
	public delegate void HeroReachedMyReach_Del(string myName, bool isHeEntering);
	public static event HeroReachedMyReach_Del HeroReachedMyReach_Ev;
	private string whoCanActivateMe {get; set;}





	
	void Awake(){
		whoCanActivateMe = so.heroObjectName;
	}



	public void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == whoCanActivateMe)
		{
			HeroReachedMyReach_Ev(myParent.name, isHeEntering : true);
		}
	}



	public void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name == whoCanActivateMe)
		{
			HeroReachedMyReach_Ev(myParent.name, isHeEntering : false);
		}
	}
}
