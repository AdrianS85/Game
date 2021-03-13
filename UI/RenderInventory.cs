using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RenderInventory : MonoBehaviour
{
    public MasterDatabaseSpawner db;
    public GameObject scrollview;
    public GameObject actualItemsGoHere;
    public List<itemTemplateSpawner> currentInventoryList;
    public float distanceBetweenItems = 100;



    void RenderNow()
    {
        currentInventoryList.Clear();

        foreach (Transform item in actualItemsGoHere.transform)
        {
            Destroy(item.gameObject);
        }
        

        
        foreach (MasterTemplateSpawner item in db.objects)
        {
            if (item.ObjectType() == "item")
            {
                itemTemplateSpawner item_ = item as itemTemplateSpawner;

                if (item_.isPickedUp == true && item_.isUsedAndDead == false)
                {
                    currentInventoryList.Add(item_ as itemTemplateSpawner);
                }
            }
        }
                   
 

        for (int itemNb = 0; itemNb < currentInventoryList.Count; itemNb++)
        {
            //currentInventoryArray.SetValue(currentInventoryList.Find(itemTemplateSpawner => itemTemplateSpawner.orderInInventory == itemNb), itemNb);

            itemTemplateSpawner item_ = currentInventoryList.Find(itemTemplateSpawner => itemTemplateSpawner.orderInInventory == itemNb);

            GameObject item_instance = Instantiate<GameObject>(item_.inventoryObject, actualItemsGoHere.transform); //placing items is taking care of by grid layout group
        }

        
    }






    void Start()
    {
        DatabaseMenager.NeedToRenderInventory_Ev += RenderNow;
    }
}
