using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InventoryControler : MonoBehaviour
{

/// CREATING INVENTORY DATA STRUCTURE BASED ON PREPARED INVENTORY ("Inventory" PANEL AND CHILD PANELS, BEING ACTUAL SLOTS FOR ITEMS) ///
    //This gives us list of slots in inventory

    [System.Serializable]
    public class Slots : System.Object
    {
        public string slotName;
        public string itemName;
        public int itemNumber;

        public Slots(string slotN, string itemN, int itemNum)
        {
           slotName = slotN;
           itemName = itemN;
           itemNumber = itemNum;
        }
    }

    public List<Slots> Inventory = new List<Slots>();

    // This adds to Inventory as many Slots, as are present as child panels of Inventory panel
    void SetUpInventorySlots(){
        foreach (Transform child in gameObject.transform)
        {
          Inventory.Add( new Slots(child.name, "", 0) );
        }
    }
/// CREATING INVENTORY DATA STRUCTURE BASED ON PREPARED INVENTORY ("Inventory" PANEL AND CHILD PANELS, BEING ACTUAL SLOTS FOR ITEMS) ///

// to implement: howMuchStacks item value, stacking to this value, displayig number of items


    void WhereToPutItem(string whichItem, GameObject instance){
        foreach (Slots slot in Inventory)
        {
          if (slot.itemName == whichItem) {
              InstantiateButton(whichItem, slot.slotName);
              Destroy(instance);
              return;
          }
          else if(slot.itemName == ""){
              InstantiateButton(whichItem, slot.slotName);
              Destroy(instance);
              return;
          }
          else{
              Debug.Log("No place in " + slot.slotName);
          }

        }
        Debug.Log("No place in inventory");
        return;
    }



    public GameObject ObjectPrefab;

    public GameObject InstantiateButton(string whichItem, string panel){
        //panel = WhereToPutItem();
        ObjectPrefab = Instantiate(Resources.Load(whichItem) as GameObject, GameObject.Find(panel).GetComponent<Transform>());

        // Here we add information on which panel has how many of which objects
        foreach (Slots slot in Inventory) {
            if (slot.slotName == panel) {
                slot.itemName = whichItem;
                slot.itemNumber++;
                Debug.Log("Slot: " + slot.slotName + "; Item: " + slot.itemName + "; ItemNb: " +  slot.itemNumber);
            }
        }
        return ObjectPrefab;
    }



    public void RemoveButton(string whichItemToRemove){
        foreach (Slots slot in Inventory)
        {
          if (slot.itemName == whichItemToRemove) {
              Debug.Log("Removing: " + slot.itemName + " from " + slot.slotName);
              slot.itemName = "";
              slot.itemNumber = 0;
              Debug.Log("Now " + slot.slotName + " includes " + slot.itemNumber + " of " + slot.itemName);
              Destroy( GameObject.Find(slot.slotName).GetComponent<Transform>().GetChild(0).gameObject );
              return;
          }
        }
    }



    public string WhereIsButton(string itemToUse){
        foreach (Slots slot in Inventory)
        {
          if (slot.itemName == itemToUse) {
              return slot.slotName;
          }
        }
        return "none";
    }



    void Awake(){
        SetUpInventorySlots();
        TakeMeBehavior.ItemTakenEvent += WhereToPutItem; // This subscribes Inventory to picking up items
        UseItemOnMeBehavior.CheckWhereIsTheItemEvent += WhereIsButton;
        UseItemOnMeBehavior.MakeItemDiseapearEvent += RemoveButton;
        //Debug.Log(Inventory[1].slotName);
    }

}
