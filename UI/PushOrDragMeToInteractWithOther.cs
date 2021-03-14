using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PushOrDragMeToInteractWithOther : _ToInteractWithOther, IPointerDownHandler
{
    public scriptableObjectSpawner so;
    public int delayToAvoidDoubleClicksAndEstablishTypeOfAction = 20;
    bool pushedAsOpposedToDragged;
    bool readyToInteract;
    public delegate void BlockMovement_Del(bool touched_ = false, bool looked_ = false, bool interacted_ = false, string myName_ = "", string interactorName_ = "", bool ui = false);
    public static event BlockMovement_Del BlockMovement_Ev;






    IEnumerator KeepObjectImageAndBlockMovement()
    {
        pushedAsOpposedToDragged = false;
        readyToInteract = false;


        
        while (true)
        {
            objectImage.transform.position = Input.mousePosition;
            BlockMovement_Ev();

            if (Input.GetMouseButtonDown(so.mouseButtonForUse) && readyToInteract && pushedAsOpposedToDragged)
            {
                CheckAndSendInteractions();
                yield break;
            }

            if (Input.GetMouseButtonUp(so.mouseButtonForUse) && readyToInteract && !pushedAsOpposedToDragged)
            {
                CheckAndSendInteractions();
                yield break;
            }

            yield return null;
        }
    }



    IEnumerator CheckIfPlayerPushedOrDraged()
    {
        int gogogo_ = 0;

        while (gogogo_ < delayToAvoidDoubleClicksAndEstablishTypeOfAction)
        {   
            if (Input.GetMouseButtonUp(so.mouseButtonForUse))
            {
                pushedAsOpposedToDragged = true;
            }
            
            gogogo_++;
            yield return null;
        }
        readyToInteract = true;
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerId == so.mouseButtonForUseEventSystem)
        {
            objectImage = SpawnObjectImageAtCoursor.Spawn(sprite, canvas, scaleForDragedObjects);
            StartCoroutine(KeepObjectImageAndBlockMovement());
            StartCoroutine(CheckIfPlayerPushedOrDraged());
        }
    }


}
