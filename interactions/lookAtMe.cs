using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtMe : MonoBehaviour
{
    public scriptableObjectSpawner so;
    public delegate void IWasLookedAt_Del(bool touched, bool looked, bool interacted, string myName, string interactorName, bool ui);
    public static event IWasLookedAt_Del IWasLookedAt_Ev;

    
    void OnMouseOver() {
        if (Input.GetMouseButtonDown(so.mouseButtonForLook))
        {
            Debug.Log("I was looked at " + gameObject.name);
            IWasLookedAt_Ev(false, true, false, gameObject.name, "dummy", false);
        }
    }

}
