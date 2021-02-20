using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementMaskerToggle : MonoBehaviour
{
    [SerializeField] int numberOfUIsOpened = 0;
    Image thisImage;
    [SerializeField] List<string> callerList;



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


    
    void Start()
    {
        UISpawner.UIActive_Ev += ChangeNumberOfUIsOpened;
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
        } else {
            thisImage.enabled = false;
        }
    }
}
