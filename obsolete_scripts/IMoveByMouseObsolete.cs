using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Well that doesnt work like it should

public class IMoveByMouseObsolete : MonoBehaviour
{

    //GameObject hero;
    Vector2 gotowards;
    Camera cam;
    float speed;

    public void Move(){
        if(Input.GetMouseButton(0)){
          gotowards = cam.ScreenToWorldPoint(Input.mousePosition);
          //hero.GetComponent<Transform>().position = Vector2.MoveTowards(transform.position, gotowards, speed * Time.deltaTime);
          transform.position = Vector2.MoveTowards(transform.position, gotowards, speed * Time.deltaTime);
          // hero.GetComponent<Transform>().position may be replaced by transform.position. Is this short version equivalent of this.transform? It seems so. So, to access component of the object to which the script is attached we need only to write component name (in lower case?) and thats it? No need to
        }

    }
    //void Pickup();
    //void Attack();

    // Start is called before the first frame update
    void Start()
    {
        //hero = this.gameObject;
        cam = Camera.main;
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}