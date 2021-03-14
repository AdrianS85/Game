using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItemOnMeBehavior : MonoBehaviour
{

    public string itemToBeUsed = "MrKeyBUTTON";

    public delegate string CheckWhereIsTheItem(string itemToUse);
    public static event CheckWhereIsTheItem CheckWhereIsTheItemEvent;

    public delegate void MakeItemDiseapear(string whichItemToRemove);
    public static event MakeItemDiseapear MakeItemDiseapearEvent;


	void OnMouseOver()
	    {

	        if( Input.GetMouseButtonDown(0) )
            {
                string slotString = CheckWhereIsTheItemEvent(itemToBeUsed);
                //Debug.Log(slotString);
                if (slotString != "none")
                {
                    MakeItemDiseapearEvent(itemToBeUsed);
                    Destroy(gameObject);
                }
			}
	    }
}
