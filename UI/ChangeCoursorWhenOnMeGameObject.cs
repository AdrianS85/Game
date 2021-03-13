using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCoursorWhenOnMeGameObject : MonoBehaviour
{
    public scriptableObjectSpawner so;

	public void OnMouseEnter() {
        Cursor.SetCursor(so.onObjectCoursor, so.onObjectCoursorHotSpot, CursorMode.Auto);
    }

    public void OnMouseExit() {
        Cursor.SetCursor(so.defaultCoursor, so.defaultCoursorHotSpot, CursorMode.Auto);
    }

}
