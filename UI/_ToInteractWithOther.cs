using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class _ToInteractWithOther : MonoBehaviour
{
    protected Camera cam;
    protected Sprite sprite;
    public GameObject objectImage;
    protected GameObject canvas;
    public Vector3 scaleForDragedObjects = new Vector3(0.8f, 0.8f, 0);
    GraphicRaycaster uiRaycaster;	
    EventSystem uiEventSystem;
    public delegate void InteractionMade_Del(bool touched, bool looked, bool interacted, string myName, string interactorName, bool ui);
    public static event InteractionMade_Del InteractionMade_Ev;


    string CheckForUiItemHit()
    {
        List<RaycastResult> results = GetUIObjectsOnMousePosition.Get(uiRaycaster, uiEventSystem);

        int nbOfUiHit = 0;

        string hitName;

        Regex regexToExtractUiObjectName = new Regex("[()]Clone.*");



        foreach (RaycastResult result in results)
        {
            if (result.gameObject.TryGetComponent(out ICanInteractWithUsedItemsUI ui) == true)
            {
                nbOfUiHit++;
                hitName = result.gameObject.name;
            }
        }



        if (nbOfUiHit == 0)
        {
            return null;
        } else if (nbOfUiHit == 1)
        {
            return regexToExtractUiObjectName.Replace(gameObject.name, "");
        } else
        {
            Debug.LogError("More than 1 UI object registered during interaction!!!");
            return null;
        }
    }



// Put ICanBeInteractedWith script into UI element that can be interacted with
    public void CheckAndSendInteractions()
    {
        string uiItem = CheckForUiItemHit();
        
        if (uiItem != null)
        {
            Debug.Log("UI item detected: " + uiItem);

            InteractionMade_Ev(touched:false, looked:false, interacted:true, myName:uiItem, interactorName:name, false);

        } else
        {
            Debug.Log("Normal item detected: " + uiItem);
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), new Vector2(0f,0f));

            if (hit.collider != null)
            {
                InteractionMade_Ev(touched:false, looked:false, interacted:true, myName:hit.collider.name, interactorName:name, false);

                /*interactionScript[] interactionScriptArray = gameObject.GetComponents<interactionScript>();
                foreach (interactionScript script in interactionScriptArray)
                {
                    script.Interact(hit.collider.gameObject);
                }*/

                // Get list of interactionScripts
            }
        }
        Destroy(objectImage);
    }



    void OnEnable()
    {
        sprite = gameObject.GetComponent<Image>().sprite;
    }



    void Start()
    {
        cam = Camera.main;
        canvas = GameObject.Find("mainCanvas"); // Meh... error prone. Better way to find parent canvas?
        uiRaycaster = canvas.GetComponent<GraphicRaycaster>();/// for blocking setting path when on UI. Also a bad ways to find gameobjects
		uiEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();/// for blocking setting path when on UI
    }
}
