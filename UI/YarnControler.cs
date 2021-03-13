using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yarn.Unity;

public class YarnControler : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public DialogueUI dialogueUI;
    public GameObject movementMasker;
    public MasterDatabaseSpawner db;
    

// Here need to make looking possible from everywhere
    public void ConversationRegistered(bool touched, bool looked, bool interacted, string myName, string interactorName, bool ui)
    {
        MasterTemplateSpawner dbObject;
        

        if (looked && ui)
        {
           
           dbObject = db.objects.Find(MasterTemplateSpawner => MasterTemplateSpawner.uniqueName == myName);

           itemTemplateSpawner dbItem;

            if (dbObject.ObjectType() == "item")
            {
                dbItem = dbObject as itemTemplateSpawner;
                dialogueRunner.StartDialogue(dbItem.uiObjectLookYarn + ".Start");
            }

        } else if (looked && !ui)
        {
            
            dbObject = db.objects.Find(MasterTemplateSpawner => MasterTemplateSpawner.uniqueName == myName);
            
            dialogueRunner.StartDialogue(dbObject.lookYarnName + ".Start");

        } else if (touched)
        {
            
            dbObject = db.objects.Find(MasterTemplateSpawner => MasterTemplateSpawner.uniqueName == myName);

            npcTemplateSpawner dbNpc;

            if (dbObject.ObjectType() == "npc")
            {
                dbNpc = dbObject as npcTemplateSpawner;
                dialogueRunner.StartDialogue(dbNpc.dialogueYarnName + ".Start");
            }
            
            //dialogueRunner.Add(npcDb.theList.Find(npcTemplateSpawner => npcTemplateSpawner.uniqueName == myName).dialogue);
        } else Debug.LogError("Name sending this signal is not present in item nor in NPC databases");

        StartCoroutine(CheckIfDialogueIsRunningAndListenForMouseClicks());
    }


    IEnumerator CheckIfDialogueIsRunningAndListenForMouseClicks()
    {
        List<string> currentListOfMenus;
        
        int gogogo = 0;
        while (gogogo < 10)
        {
            gogogo++;
            yield return null;
            //Debug.Log(movementMasker.GetComponent<MovementMaskerToggle>().GetCurrentlyActiveMenu());
        } // Cause of delay in registering movementmasker list? Perhaps unneccesary?

        currentListOfMenus = movementMasker.GetComponent<MovementMaskerToggle>().GetCurrentlyActiveMenus();

        while (currentListOfMenus.Find(x => x == "dialogue_box") != null) // To avoid bugs connected to entering and exiting other menus while in dialogue
        {
            currentListOfMenus = movementMasker.GetComponent<MovementMaskerToggle>().GetCurrentlyActiveMenus();
            
            //Debug.Log("IsDialogueCurrentlyActive");

            if (Input.GetMouseButtonDown(0) && currentListOfMenus.LastOrDefault<string>() == "dialogue_box") // Get so to establish names of components generally
            {
                //Debug.Log("IsDialogueCurrentlyActive - pressed 0 button");
                dialogueUI.MarkLineComplete();
            }            
            yield return null;
        }
    } // this can have a problem, that exiting main menu also forwards conversation



    void OnEnable() {
        MoveToMeStopAndDoStuff.StopMoving_Ev += ConversationRegistered;
        lookAtMe.IWasLookedAt_Ev += ConversationRegistered;
        lookAtMeUI.IWasLookedAtUI_Ev += ConversationRegistered;
    }

}
