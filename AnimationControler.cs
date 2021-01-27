using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put in the same object that has Animator

public class AnimationControler : MonoBehaviour
{
    private Animator animator;
    public bool doesHeMove;

    void Animate(bool doesHeMove__, string direction_)
    {
        doesHeMove = doesHeMove__;
        
        if (doesHeMove__ == true)
        {          
            if (direction_ == "u")
            {
                animator.Play("up");
            } else if (direction_ == "d")
            {
                animator.Play("down");
            } else if (direction_ == "r")
            {
                animator.Play("right");
            } else if (direction_ == "l")
            {
                animator.Play("left");
            }
        } else if (doesHeMove__ == false)
        {          
            if (direction_ == "u")
            {
                animator.Play("idle_up");
            } else if (direction_ == "d")
            {
                animator.Play("idle_down");
            } else if (direction_ == "r")
            {
                animator.Play("idle_right");
            } else if (direction_ == "l")
            {
                animator.Play("idle_left");
            }
        }


    }
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        eventmanagerScript.heroMovementEMBroadcastEvent += Animate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
