using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMeBehavior : MonoBehaviour {

	GameObject vitalityContainerObject;
	string vitalityContainer {set; get;}


	void OnMouseOver()
	    {
	        if( Input.GetMouseButtonDown(0) ){
				vitalityContainer = "GO_Vitality";
				Debug.Log("Nom");
				vitalityContainerObject = GameObject.Find(vitalityContainer);
				vitalityContainerObject.GetComponent<V_CounterDowner>().valueChangeBy(1);
				//Debug.Log(vitalityContainerObject.name);
				Destroy(gameObject);
				}
	    }
}
