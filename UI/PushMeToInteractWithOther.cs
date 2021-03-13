using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PushMeToInteractWithOther : _ToInteractWithOther, IPointerDownHandler
{
    public scriptableObjectSpawner so;
    public delegate void BlockMovement_Del(bool touched_ = false, bool looked_ = false, bool interacted_ = false, string myName_ = "", string interactorName_ = "", bool ui = false);
    public static event BlockMovement_Del BlockMovement_Ev;

    IEnumerator KeepObjectImageAndBlockMovement() {
        int gogogo = 0;
        while (gogogo < 10)
        {
            gogogo++;
            yield return null;
        }
        
        while (!Input.GetMouseButtonDown(so.mouseButtonForUse))
        {
            objectImage.transform.position = Input.mousePosition;
            BlockMovement_Ev();
            yield return null;
        }

        CheckAndSendInteractions();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerId == so.mouseButtonForUseEventSystem)
        {
            objectImage = SpawnObjectImageAtCoursor.Spawn(sprite, canvas, scaleForDragedObjects);
            StartCoroutine(KeepObjectImageAndBlockMovement());
        }
    }
}
