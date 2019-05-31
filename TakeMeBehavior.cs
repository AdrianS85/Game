using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class TakeMeBehavior : MonoBehaviour {

    public string whichItemIsThis;

    //public delegate GameObject ItemTaken(string whichItem, int instanceID);
    public delegate void ItemTaken(string whichItem, GameObject instance);
    public static event ItemTaken ItemTakenEvent;

    void Awake(){
        //All items need to end with "ITEM". All UI buttons of items need to end with "BUTTON"
        whichItemIsThis = Regex.Replace(this.gameObject.name, "ITEM.*", "") + "BUTTON";
    }

	void OnMouseOver()
	    {
	        if( Input.GetMouseButtonDown(0) ){
                ItemTakenEvent(whichItemIsThis, this.gameObject);
				}
	    }
}
