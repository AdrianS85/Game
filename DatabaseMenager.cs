using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseMenager : MonoBehaviour
{
    public databaseSpawner db;
    int pickupOrder = 0;

    public delegate void NeedToRenderInventory_Del();
    public static event NeedToRenderInventory_Del NeedToRenderInventory_Ev;





    void AddObjectToList(string objectName, bool yes){

        itemTemplateSpawner eaten_item = db.theList.Find(itemTemplateSpawner => itemTemplateSpawner.uniqueName == objectName);

        if (eaten_item != null)
        {
            eaten_item.isPickedUp = true;

            eaten_item.orderInInventory = pickupOrder;

            pickupOrder++;

            NeedToRenderInventory_Ev();
        }
    }


    /*int FindHighestValueInListOrder(List<itemTemplateSpawner> itemList){

        int highestValueInOrder;
        int[] valuesInList = new int[itemList.Count];;



        int currentItemNumber = 0;

        foreach (itemTemplateSpawner item in itemList)
        {
            //Debug.Log("Item number: " + currentItemNumber + "\n" + "Item order: " + item.orderInInventory);
            valuesInList[currentItemNumber] = item.orderInInventory;
            currentItemNumber ++;
        }

        Array.Sort(valuesInList);
        Debug.Log(valuesInList);

        highestValueInOrder = valuesInList[0];

        return highestValueInOrder+1;
    }*/


    void RemoveObjectFromList(string objectName, bool yes){
    }


    void UpdateListOrder(){
    }






 



    private void Start() {

        InteractWithMeObject.AteMe_Ev += AddObjectToList;
        
    }
}
