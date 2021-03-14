using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public static class GetUIObjectsOnMousePosition : object
{
    public static List<RaycastResult> Get(GraphicRaycaster gr, EventSystem es)
    {
        PointerEventData ped;
        
        ped = new PointerEventData(es);
        ped.position = Input.mousePosition;
        List<RaycastResult> returnList = new List<RaycastResult>();
        gr.Raycast(ped, returnList);

        return returnList;
    }
}
