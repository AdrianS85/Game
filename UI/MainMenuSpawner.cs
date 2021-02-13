using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpawner : UISpawner
{
    
    void Start()
    {
        PressMeToEnterMainMenu.StartMainMenu_Ev += SpawnUI;
        whereToSpawnMe = so.whereToSpawnMainMenu; /// !!! To be changed ?based on UI object
        whereToDespawnMe = so.whereToDespawnMainMenu; /// !!! To be changed ?based on UI object
    }
}
