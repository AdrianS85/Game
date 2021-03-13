
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSpawner : UISpawner
{
    public MasterDatabaseSpawner npcDb;
    public GameObject rightPicture;
    public GameObject leftPicture;
    public GameObject currentText;
    public List<GameObject> dialogueOptions = new List<GameObject>();
    [SerializeField] MasterTemplateSpawner currentTalker;



    void SetFaceOfNpc(bool touched, bool looked, bool interacted, string myName, string interactorName, bool ui) {
        currentTalker = null;

        currentTalker = npcDb.objects.Find(MasterTemplateSpawner => MasterTemplateSpawner.uniqueName == myName);

        rightPicture.GetComponent<Image>().overrideSprite = currentTalker.faceSpriteNeutral;
    }



    void OnEnable() {
        InteractWithMePerson.IWasTalkedTo_Ev += SpawnUI;
        InteractWithMePerson.IWasTalkedTo_Ev += SetFaceOfNpc;
        lookAtMe.IWasLookedAt_Ev += SpawnUI;
        lookAtMe.IWasLookedAt_Ev += SetFaceOfNpc;
        lookAtMeUI.IWasLookedAtUI_Ev += SpawnUI;
        lookAtMeUI.IWasLookedAtUI_Ev += SetFaceOfNpc;
    }
    


    void Start() {
        whereToSpawnMe = new Vector3(0.5f,200f,1f); /// !!! To be changed based on UI object
        whereToDespawnMe = new Vector3(300f,300f,1f); /// !!! To be changed based on UI object

        gameObject.GetComponent<RectTransform>().localPosition = whereToDespawnMe;

        DeSpawnUI();
        //whereToSpawnMe = so.whereToSpawnDialogueBox; /// !!! To be changed ?based on UI object
        //whereToDespawnMe = so.whereToDespawnDialogueBox; /// !!! To be changed ?based on UI object
    }
}
