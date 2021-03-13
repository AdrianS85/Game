using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateYourInteractivity : MonoBehaviour
{
    void SetInteractivityState(bool isActivated)
    {
        gameObject.GetComponent<Collider2D>().enabled = !isActivated;
    }


    void OnEnable()
    {
        MovementMaskerToggle.UIMaskActivationState_Ev += SetInteractivityState;
    }
}
