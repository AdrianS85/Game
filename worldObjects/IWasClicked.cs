using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IWasClicked : MonoBehaviour
{
    public scriptableObjectSpawner so;

    public delegate void HeClickedMe_Del(bool touched, bool looked, string myName);
	public static event HeClickedMe_Del HeClickedMe_Ev;
    
    


	public void OnMouseOver()
    {
        if( Input.GetMouseButtonDown(so.mouseButtonForUse) ){
            HeClickedMe_Ev(touched : true, looked : false, myName : gameObject.name);
            }

        if( Input.GetMouseButtonDown(so.mouseButtonForLook) ){
            HeClickedMe_Ev(touched : false, looked : true, myName : gameObject.name);
            }
    }

}
