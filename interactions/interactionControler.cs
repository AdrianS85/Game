using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;

public class interactionControler : MonoBehaviour
{
    //public GameObject interactor;
    public Regex regexToExtractUiObjectName = new Regex("_ui.*");
    public string myDatabaseName;
    public string myInteractorName;
    public enum interactionTypes
    {
        one,
        two
    }
    public GenericDictionary<MasterTemplateSpawner, interactionTypes> interactionDict; //https://github.com/upscalebaby/generic-serializable-dictionary
    public List<string> objectsWithWhichIInteract;

  
    public void GetObjectsWithWhichIInteract()
    {
        foreach (MasterTemplateSpawner item in interactionDict.Keys)
        {
            objectsWithWhichIInteract.Add(item.uniqueName);
        }
    }


    public void DefaultInteraction(string myInteractorName_)
    {
        if (!objectsWithWhichIInteract.Contains(myInteractorName_))
        {
            Debug.Log("I can't do that");
        } else if (objectsWithWhichIInteract.Contains(myInteractorName_))
        {

            /*foreach (var item in interactionDict)
            {
                Debug.Log("I can do that");
            }      */     
        }

    }
    

    public void RegisterInteractors(bool touched, bool looked, bool interacted, string myName, string interactorName, bool ui)
    {
        Debug.Log(myDatabaseName + " also known as " + interactorName + " interacted with " + myName);
        myInteractorName = myName;

        DefaultInteraction(myInteractorName);
    }



    void OnEnable()
    {
        myDatabaseName = regexToExtractUiObjectName.Replace(gameObject.name, "");
    }


    void Start()
    {
        _ToInteractWithOther.InteractionMade_Ev += RegisterInteractors;
        GetObjectsWithWhichIInteract();
    }
}

