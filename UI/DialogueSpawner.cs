
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSpawner : UISpawner
{

    
    void Start()
    {
        whereToSpawnMe = new Vector3(0.5f,200f,1f); /// !!! To be changed based on UI object
        whereToDespawnMe = new Vector3(300f,300f,1f); /// !!! To be changed based on UI object

        gameObject.GetComponent<RectTransform>().localPosition = whereToDespawnMe;

        DeSpawnUI();
        InteractWithMePerson.IWasTalkedTo_Ev += SpawnUI;
        //whereToSpawnMe = so.whereToSpawnDialogueBox; /// !!! To be changed ?based on UI object
        //whereToDespawnMe = so.whereToDespawnDialogueBox; /// !!! To be changed ?based on UI object
    }

}
