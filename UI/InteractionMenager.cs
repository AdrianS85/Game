using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMenager : MonoBehaviour
{
    public interactionsSpawner intDb;

    public void ProcessInteraction(bool touched, bool looked, bool interacted, string myName, string interactorName)
    {     
        if (interacted)
        {
            interactorName = interactorName.Replace("(Clone)", ""); // Cause spawned version of items have this post-index
            
            interactionTemplateSpawner interaction = intDb.theList.Find(interactionTemplateSpawner => interactionTemplateSpawner.interactUsingThisObject.name == interactorName && interactionTemplateSpawner.onThisObject.name == myName);

            if (interaction != null)
            {
                Debug.Log(interaction.effectString);
                //Debug.Log("You have used interactorName: " + interactorName + " with myName: " + myName + " returning interaction: " + interaction.effectString + ". \nIn database You had " + interaction.interactUsingThisObject.name + " and " + interaction.onThisObject.name);
            }
        }
    }


    void Start()
    {
        DragMeToInteractWithOther.InteractionMade_Ev += ProcessInteraction;
    }
}
