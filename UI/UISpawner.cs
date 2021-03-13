using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UISpawner : MonoBehaviour
{
    public scriptableObjectSpawner so;
    //protected bool isUIActive = false;
    //public string thisGOName;
    string gOname;
    protected Vector3 whereToSpawnMe;
    protected Vector3 whereToDespawnMe;
    public delegate void UIActive_Del(string callerName, bool activated);
    public static event UIActive_Del UIActive_Ev;

    public delegate void StopMovement_Del(bool touched_ = false, bool looked_ = false, bool interacted_ = false, string myName_ = "dummy", string interactorName_ = "dummy", bool ui = false);
    public static event StopMovement_Del StopMovement_Ev;
    
    public List<GameObject> myUIChildren;





    public void SpawnUI(bool touched, bool looked, bool interacted, string myName, string interactorName, bool ui){
        foreach (GameObject child in myUIChildren)
        {
            child.SetActive(true);
        }

        gameObject.GetComponent<RectTransform>().localPosition = whereToSpawnMe; /// !!! will need to convert coordinates to viewport, as here: https://forum.unity.com/threads/solved-how-to-convert-recttransform-localposition-to-viewport-coordinates-for-opengl.382353/ , but i don wanna do it now
        UIActive_Ev(gameObject.name, true);

        StopMovement_Ev();
        }



    public void DeSpawnUI(){
        foreach (GameObject child in myUIChildren)
        {
            child.SetActive(false);
        }

        gameObject.GetComponent<RectTransform>().localPosition = whereToDespawnMe; /// !!! will need to convert coordinates to viewport, as here: https://forum.unity.com/threads/solved-how-to-convert-recttransform-localposition-to-viewport-coordinates-for-opengl.382353/ , but i don wanna do it now

        UIActive_Ev(gameObject.name, false);
    }
}