using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RenderInventory : MonoBehaviour
{
    public databaseSpawner db;
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
        
        
        foreach (itemTemplateSpawner item in db.theList)
        {
            if (item.isPickedUp == true && item.isUsedAndDead == false)
            {
                currentInventoryList.Add(item);
            }
        }
 

        for (int itemNb = 0; itemNb < currentInventoryList.Count; itemNb++)
        {
            //currentInventoryArray.SetValue(currentInventoryList.Find(itemTemplateSpawner => itemTemplateSpawner.orderInInventory == itemNb), itemNb);

            itemTemplateSpawner item_ = currentInventoryList.Find(itemTemplateSpawner => itemTemplateSpawner.orderInInventory == itemNb);

            GameObject item_instance = Instantiate<GameObject>(item_.inventoryObject, actualItemsGoHere.transform);

            Vector3 putItemHere = new Vector3(0+(itemNb*distanceBetweenItems),0,0) + actualItemsGoHere.GetComponent<RectTransform>().localPosition;

            item_instance.GetComponent<RectTransform>().localPosition = putItemHere;


        }
    }






    void Start()
    {
        DatabaseMenager.NeedToRenderInventory_Ev += RenderNow;
    }
}
