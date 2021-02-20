using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PressMeToEnterMainMenu : MonoBehaviour, IPointerDownHandler
{
    public delegate void StartMainMenu_Del(string dummy, bool yes);
    public static event StartMainMenu_Del StartMainMenu_Ev;



    public void OnPointerDown(PointerEventData eventData) {
        StartMainMenu_Ev("dummy", true);
    }

}
