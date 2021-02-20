using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResetSOs : MonoBehaviour, IPointerDownHandler
{
    public List<itemTemplateSpawner> toResetItems;

    public void OnPointerDown(PointerEventData eventData) 
    {
        foreach (itemTemplateSpawner item in toResetItems) {
            item.isPickedUp = false;
            item.isUsedAndDead = false;
            item.orderInInventory = 0;
        }
    }
}
