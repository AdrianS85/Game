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


    
    void MoveToMeStopAndDo(bool touched, bool looked, string myName){
        if (myName == gameObject.name)
        {
            Debug.Log("MoveToMeStopAndDoStuff");
            StartCoroutine(WaitForColisionAndStopMovement());
        }
    }



    private void Start() {
        IWasClicked.HeClickedMe_Ev += MoveToMeStopAndDo;
        ActivateMyParentOnTriggeringMyCollider.HeroReachedMyReach_Ev += DidWeReachInteractionRange;
    }




}
