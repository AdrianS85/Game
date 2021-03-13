using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragMeToInteractWithOther : _ToInteractWithOther, IDragHandler,IBeginDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        objectImage = SpawnObjectImageAtCoursor.Spawn(sprite, canvas, scaleForDragedObjects);
    }

    public void OnDrag(PointerEventData data)
    {
        objectImage.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CheckAndSendInteractions();
    }
}
