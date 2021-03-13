using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMeStopAndDoStuff : MonoBehaviour
{
    /// !!! Now we need only for object to be picked up and we are golden
    [SerializeField] bool canWeInteractNow = false;
    public delegate void StopMoving_Del(bool touched__, bool looked__, bool interacted__, string myName__, string interactorName__, bool ui);
    public static event StopMoving_Del StopMoving_Ev;



    //forIgnoringFirstClick - Cause function registers also click that started it
    IEnumerator WaitForColisionAndStopMovement(bool touched_, bool looked_, bool interacted_, string myName_, string interactorName_, bool ui){
        bool forIgnoringFirstClick = false; 

        while (canWeInteractNow == false)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                if (forIgnoringFirstClick == false)
                {
                    forIgnoringFirstClick = true;
                } else
                {
                    yield break;
                }
            }
            yield return null;
        }
        StopMoving_Ev(touched_, looked_, interacted_, myName_, interactorName_, ui);
    }



    void DidWeReachInteractionRange(string objectReached, bool isItReached){
        if (objectReached == gameObject.name)
        {
            canWeInteractNow = isItReached;
        }
    }


    
    void MoveToMeStopAndDo(bool touched, bool looked, bool interacted, string myName, string interactorName, bool ui){
        if (myName == gameObject.name)
        {
            StartCoroutine(WaitForColisionAndStopMovement(touched, looked, interacted, myName, interactorName, ui)); // issue is - jak nie dotrzesz a miejsce, bo klikniesz gdzie indziej, a potem tam wrócisz, to automatycznie podniesie obiekt
        }
    }



    private void Start() {
        IWasClicked.HeClickedMe_Ev += MoveToMeStopAndDo;
        ActivateMyParentOnTriggeringMyCollider.HeroReachedMyReach_Ev += DidWeReachInteractionRange;
        _ToInteractWithOther.InteractionMade_Ev += MoveToMeStopAndDo;
    }
}
