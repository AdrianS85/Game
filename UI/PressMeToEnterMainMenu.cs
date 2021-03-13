using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PressMeToEnterMainMenu : MonoBehaviour, IPointerDownHandler
{
    public delegate void StartMainMenu_Del(bool touched, bool looked, bool interacted, string myName, string interactorName, bool ui);
    public static event StartMainMenu_Del StartMainMenu_Ev;



    public void OnPointerDown(PointerEventData eventData) {
        StartMainMenu_Ev(false, false, false, "dummy", "dummy", false);
    }

}
