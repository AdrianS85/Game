using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragMeToInteractWithOther : MonoBehaviour, IDragHandler,IBeginDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    public delegate void InteractionMade_Del(bool touched, bool looked, bool interacted, string myName, string interactorName);
    public static event InteractionMade_Del InteractionMade_Ev;
    Camera cam;



    public void OnDrag(PointerEventData data)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), new Vector2(0f,0f));

        if (hit.collider != null)
        {
            InteractionMade_Ev(touched:false, looked:false, interacted:true, myName:hit.collider.name, interactorName:name);
        }

        // TUtaj musimy wysłać ten sygnał do jakiegoś przetwarzacza, który określi czy interakcja moze nastąpić (czy podłączonego so) i jesli tak, to włączy AIStar
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Here we change coursor to include picture of an item
    }


    void Start()
    {
        cam = Camera.main;
    }
}
