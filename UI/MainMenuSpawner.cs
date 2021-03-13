using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpawner : UISpawner
{
    
    void OnEnable() {
        PressMeToEnterMainMenu.StartMainMenu_Ev += SpawnUI;
    }
    
    void Start() {
        whereToSpawnMe = new Vector3(0.5f,0.5f,1f); /// !!! To be changed based on UI object
        whereToDespawnMe = new Vector3(-300f,-300f,1f); /// !!! To be changed based on UI object

        gameObject.GetComponent<RectTransform>().localPosition = whereToDespawnMe;
        
        DeSpawnUI();
        
        //whereToSpawnMe = so.whereToSpawnMainMenu; /// !!! To be changed ?based on UI object
        //whereToDespawnMe = so.whereToDespawnMainMenu; /// !!! To be changed ?based on UI object
    }
}
