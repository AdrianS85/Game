using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GeneralSetup : MonoBehaviour
{
    public scriptableObjectSpawner so;

    void Start() {
        //temp = new Sprite.Create(so.defaultCoursor, Rect rect, Vector2(0,0));
        
        Cursor.SetCursor(so.defaultCoursor, so.defaultCoursorHotSpot, CursorMode.Auto);
    }


}
