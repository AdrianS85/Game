using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PressMeToDeactivateUISet : MonoBehaviour, IPointerDownHandler
{
    public GameObject objectWithUISpawner;

    UISpawner uISpawner;


    void Awake() {
        uISpawner = objectWithUISpawner.GetComponent<UISpawner>();
    }


    public void OnPointerDown(PointerEventData eventData) {
        uISpawner.DeSpawnUI();
    }
}