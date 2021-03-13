using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IWasClicked : MonoBehaviour
{
    public scriptableObjectSpawner so;

    public delegate void HeClickedMe_Del(bool touched, bool looked, bool interacted, string myName, string interactorName, bool ui);
	public static event HeClickedMe_Del HeClickedMe_Ev;
    


	public void OnMouseOver()
    {   
        if( Input.GetMouseButtonDown(so.mouseButtonForUse) ){
            
            HeClickedMe_Ev(touched:true, looked:false, interacted:false, myName:gameObject.name, interactorName:"dummy", false);
            }

        if( Input.GetMouseButtonDown(so.mouseButtonForLook) ){
            HeClickedMe_Ev(touched:false, looked:true, interacted:false, myName:gameObject.name, interactorName:"dummy", false);
            }
    }

}
