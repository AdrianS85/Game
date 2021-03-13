using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeCoursorWhenOnMeUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public scriptableObjectSpawner so;

	public void OnPointerEnter(PointerEventData pointerEventData) {
        Cursor.SetCursor(so.onObjectCoursor, so.onObjectCoursorHotSpot, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData pointerEventData) {
        Cursor.SetCursor(so.defaultCoursor, so.defaultCoursorHotSpot, CursorMode.Auto);
    }
}
