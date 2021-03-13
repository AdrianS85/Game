using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _ToInteractWithOther : MonoBehaviour
{
    protected Camera cam;
    protected Sprite sprite;
    public GameObject objectImage;
    protected GameObject canvas;
    public Vector3 scaleForDragedObjects = new Vector3(0.8f, 0.8f, 0);
    public delegate void InteractionMade_Del(bool touched, bool looked, bool interacted, string myName, string interactorName, bool ui);
    public static event InteractionMade_Del InteractionMade_Ev;



    public void CheckAndSendInteractions()
    {
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
    }
}
