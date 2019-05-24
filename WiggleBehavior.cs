using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleBehavior : MonoBehaviour
{

    Vector2 whereto;

    public Vector2 Whereto(){
        return new Vector2(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f));
    }

    void Update()
    {
        this.GetComponent<Transform>().Translate(Whereto() * Time.deltaTime);
    }
}
