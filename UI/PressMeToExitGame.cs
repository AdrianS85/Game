using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PressMeToExitGame : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData) {
        // here probably do some game saving
        Debug.Log("GAME QUIT!");
        Application.Quit();
    }
}