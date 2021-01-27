/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockMovementUponClicking : MonoBehaviour, IPointerDownHandler
{
    public delegate void BlockMovementUponClickingDelegate(bool shouldIBlockMovement);
    public static event BlockMovementUponClickingDelegate BlockMovementUponClickingEvent;

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("ass");
        BlockMovementUponClickingEvent(shouldIBlockMovement : true);
    }

}
*/