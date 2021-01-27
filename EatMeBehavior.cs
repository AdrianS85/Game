using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //

public class EatMeBehavior : MonoBehaviour {

	public scriptableObjectSpawner so;
	public delegate void AteMeDelegate(string objectName, int button_);
	public static event AteMeDelegate AteMeEvent;

	private void Start() {
		this.enabled = false;
	}


	public void OnMouseOver() // can this be exchanged for OnMouseDown()???
	    {
	        if( Input.GetMouseButtonDown(so.mouseButtonForUse) && this.enabled == true ){
				Debug.Log("EatMeBehavior: Nom " + gameObject.name);
				GameObject.Destroy(this.gameObject);
				}

			if( Input.GetMouseButtonDown(so.mouseButtonForLook) && this.enabled == true ){
				Debug.Log("Hello. I have a little story for You all... ");
				AteMeEvent(this.gameObject.name, so.mouseButtonForLook);
				}
	    }


	void OnDestroy() {
		AteMeEvent(this.gameObject.name, so.mouseButtonForUse);
	}

}