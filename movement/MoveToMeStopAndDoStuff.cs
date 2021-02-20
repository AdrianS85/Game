using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMeStopAndDoStuff : MonoBehaviour
{
    /// !!! Now we need only for object to be picked up and we are golden
    [SerializeField] bool canWeInteractNow = false;

    public delegate void StopMoving_Del(string objectName);
    public static event StopMoving_Del StopMoving_Ev;



    
    IEnumerator WaitForColisionAndStopMovement(){
        while (canWeInteractNow == false)
        {
            yield return null;
        }
        StopMoving_Ev(gameObject.name);
    }

    void DidWeReachInteractionRange(string objectReached, bool isItReached){
        if (objectReached == gameObject.name)
        {
            canWeInteractNow = isItReached;
        }
    }


    
    void MoveToMeStopAndDo(bool touched, bool looked, bool interacted, string myName, string interactorName){
        if (myName == gameObject.name)
        {
            StartCoroutine(WaitForColisionAndStopMovement()); // issue is - jak nie dotrzesz a miejsce, bo klikniesz gdzie indziej, a potem tam wrócisz, to automatycznie podniesie obiekt
        }
    }



    private void Start() {
        IWasClicked.HeClickedMe_Ev += MoveToMeStopAndDo;
        ActivateMyParentOnTriggeringMyCollider.HeroReachedMyReach_Ev += DidWeReachInteractionRange;
        DragMeToInteractWithOther.InteractionMade_Ev += MoveToMeStopAndDo;
    }




}
