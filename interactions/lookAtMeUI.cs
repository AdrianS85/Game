using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;

public class lookAtMeUI : MonoBehaviour, IPointerDownHandler
{
    public scriptableObjectSpawner so;
    public Regex regexToExtractUiObjectName = new Regex("_ui.*");

    public delegate void IWasLookedAtUI_Del(bool touched, bool looked, bool interacted, string myName, string interactorName, bool ui);
    public static event IWasLookedAtUI_Del IWasLookedAtUI_Ev;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        string baseObjectName;
        
        if (pointerEventData.pointerId == so.mouseButtonForLookEventSystem)
        {
            baseObjectName = regexToExtractUiObjectName.Replace(gameObject.name, "");

            IWasLookedAtUI_Ev(false, true, false, baseObjectName, "dummy", true);

            //Debug.Log(baseObjectName);
        }
        
    }



}
