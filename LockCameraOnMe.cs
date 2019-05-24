using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCameraOnMe : MonoBehaviour
{
    GameObject hero;
    Vector3 gotowards;
    Camera cam;

    public void followMe(){
        cam.GetComponent<Transform>().position = new Vector3
        (
            hero.GetComponent<Transform>().position.x,
            hero.GetComponent<Transform>().position.y,
            -10
        );
    }

    void Awake()
    {
        hero = this.gameObject;
        cam = Camera.main;
    }

    void LateUpdate()
    {
        followMe();
    }
}
