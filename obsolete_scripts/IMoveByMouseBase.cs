/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public class IMoveByMouseBase : MonoBehaviour
{
    
    Camera cam;
    public float speed;
    public int mouseButtonToUse;
    public int coliderLayerThatStopsMovement;
    private Vector2 movementTarget;
    private bool isTargetReached;

// Set all rigidbody proerties to appropriate in awake


    public void Move(Vector2 clickedTarget_, float MovementSpeed_){

            Vector2 stepTowardTarget;


            //clickedTarget_ = ReferenceCamera_.ScreenToWorldPoint(Input.mousePosition);

            stepTowardTarget = new Vector2(
                Mathf.MoveTowards(transform.position.x, clickedTarget_.x, MovementSpeed_), 
                Mathf.MoveTowards(transform.position.y, clickedTarget_.y, MovementSpeed_));
 
            GetComponent<Rigidbody2D>().MovePosition(stepTowardTarget);
    }



    void Start()
    {
        cam = Camera.main;
        speed = 0.2f;
        mouseButtonToUse = 0;
        isTargetReached = false;
        coliderLayerThatStopsMovement = 1;

        Assert.AreEqual(RigidbodyType2D.Dynamic, GetComponent<Rigidbody2D>().bodyType);
    }



    void FixedUpdate()
    {
        if (Input.GetMouseButton(mouseButtonToUse) == true)
        {
            movementTarget = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (transform.position.x == movementTarget.x && transform.position.y == movementTarget.y)
        {
            isTargetReached = true;
        }

        Move(
            clickedTarget_ : movementTarget, 
            MovementSpeed_ : speed);

        isTargetReached = false;
    }
}
//GetComponent<Rigidbody2D>().IsTouchingLayers(coliderLayerThatStopsMovement)
/*
    public void Move(bool IsClicked_, float MovementSpeed_, Camera ReferenceCamera_){
        if(IsClicked_ == true){
            
            Vector2 clickedTarget;

            clickedTarget = ReferenceCamera_.ScreenToWorldPoint(Input.mousePosition);

            transform.position = Vector2.MoveTowards(transform.position, clickedTarget, MovementSpeed_ * Time.deltaTime);
            // hero.GetComponent<Transform>().position may be replaced by transform.position. Is this short version equivalent of this.transform? It seems so. So, to access component of the object to which the script is attached we need only to write component name (in lower case?) and thats it? No need to
        }
    }


            //Rigidbody2D.OverlapPoint , MoveRotation
            //CharacterController
            //Mathf.MoveTowards
            //https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnAnimatorMove.html
    */