
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSpawner : UISpawner
{

    
    void Start()
    {
        InteractWithMePerson.IWasTalkedTo_Ev += SpawnUI;
        whereToSpawnMe = so.whereToSpawnDialogueBox; /// !!! To be changed ?based on UI object
        whereToDespawnMe = so.whereToDespawnDialogueBox; /// !!! To be changed ?based on UI object
    }
}
