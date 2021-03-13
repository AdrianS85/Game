using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MovementMaskerToggle : MonoBehaviour
{
    [SerializeField] int numberOfUIsOpened = 0;
    Image thisImage;
    public List<string> callerList;


    public List<string> GetCurrentlyActiveMenus(){
        return callerList;
    }
    /*public List<string> GetCurrentlyActiveMenus(){
        if (callerList != null)
        {
            return callerList.LastOrDefault<string>();
        } else return null;
    }*/

    void ChangeNumberOfUIsOpened(string callerName, bool activated){
        
        if (callerList.Contains(callerName))
        {
            if (activated == false)
            {
                numberOfUIsOpened --;
                callerList.Remove(callerName);
            }
        } else{
            if (activated == true)
            {
                numberOfUIsOpened ++;
                callerList.Add(callerName);
            }
        }
    }



    /*    void ChangeNumberOfUIsOpened(string callerName, bool activated){
        
        if (callerList.Contains(callerName))
        {
            if (activated == false)
            {
                numberOfUIsOpened --;
                callerList.Remove(callerName);
            }
        } else{
            if (activated == true)
            {
                numberOfUIsOpened ++;
                callerList.Add(callerName);
            }
        }
    }*/

    public delegate void UIMaskActivationState_Del(bool isActivated);
    public static event UIMaskActivationState_Del UIMaskActivationState_Ev;

    


    
    void OnEnable()
    {
        UISpawner.UIActive_Ev += ChangeNumberOfUIsOpened;
    }
    
    void Start()
    {
        thisImage = gameObject.GetComponent<Image>();
    }



    void Update(){
         if (numberOfUIsOpened < 0)
         {
             numberOfUIsOpened = 0;
         }


        if (numberOfUIsOpened != 0)
        {
            thisImage.enabled = true;
            UIMaskActivationState_Ev(true);
            // Send event to items to deactivate their colliders?
        } else {
            thisImage.enabled = false;
            UIMaskActivationState_Ev(false);
        }
    }
}
