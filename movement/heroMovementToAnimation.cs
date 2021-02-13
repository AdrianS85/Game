using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class heroMovementToAnimation : MonoBehaviour
{
    public scriptableObjectSpawner so;
    Animator animator;
    [SerializeField] Vector2 previousPlayerPosition;
    [SerializeField] string playerDirection;
    string previousPlayerDirection;
    [SerializeField] bool doesHeMove__;
    [SerializeField] float velocityBufferForChangingMovementDir = 0.1f; // this will need to ba changed based on scriptable object velocity setter

    bool playNonMovementAnimation = false;
    
    



    // Tutaj jitter może być spowodowany tym, że 45 stopni łatwo może przeskoczyc między 44.9 a 45. Zróbmy może tak, że weźmy poprawkę na obliczanie kierunku ruchu biorąc pod uwagę poprzedni kierunek ruchu. MOże tak: jeśli już idzie w którąś stronę, to zmieńmy tą stronę tylko jak kierunek ruchu wyraźnie się zmieni




    void Animate(bool doesHeMove, Vector3 currentVelocity)
    {
        doesHeMove__ = doesHeMove;

        if (doesHeMove == true && playNonMovementAnimation == false)
        {  
            
            // All of this is so that there are no jitter when movement direction is on border between 45 degrees and 44.9 degrees
            float velX = currentVelocity.x;
            float velY = currentVelocity.y;

            float aVelX = Mathf.Abs(velX);
            float aVelY = Mathf.Abs(velY);

            if (previousPlayerDirection == "u")
            {
                aVelX = aVelX - velocityBufferForChangingMovementDir;

            } else if (previousPlayerDirection == "d")
            {
                aVelX = aVelX - velocityBufferForChangingMovementDir;

             } else if (previousPlayerDirection == "r")
            {
                aVelX = aVelX + velocityBufferForChangingMovementDir;

             } else if (previousPlayerDirection == "l")
            {
                aVelX = aVelX + velocityBufferForChangingMovementDir;

            }




            if (aVelX < aVelY & velY > 0)
            {
                    playerDirection = "u";
                    animator.Play("up");

            } else if (aVelX < aVelY & velY < 0)
            {
                    playerDirection = "d";
                    animator.Play("down");

            } else if (aVelX > aVelY & velX > 0)
            {
                    playerDirection = "r";
                    animator.Play("right");

            } else if (aVelX > aVelY & velX < 0)
            {
                    playerDirection = "l";
                    animator.Play("left");

            } else
            {
                playerDirection = previousPlayerDirection;
            }
        }  else if (doesHeMove__ == false && playNonMovementAnimation == false)
        {          
            if (playerDirection == "u")
            {
                animator.Play("idle_up");

            } else if (playerDirection == "d")
            {
                animator.Play("idle_down");

            } else if (playerDirection == "r")
            {
                animator.Play("idle_right");

            } else if (playerDirection == "l")
            {
                animator.Play("idle_left");
            } /// !!! tutuaj pewnie trzeba dodać ostatnie else, które każe mu być obróconym w stronę w którą ostatnio był odwrócony
        } else if (playNonMovementAnimation == true)
        {
            return;
        }

        previousPlayerDirection = playerDirection;

    }

/*
    IEnumerator PlayNonMovementAnimation(){
        animator.Play("pickup");
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("pickup"))
        {
            Debug.Log("coroutine running");
            yield return null;
        }
        Debug.Log("coroutine stop");
        playNonMovementAnimation = false;
    }

    void PlayPickupAnimation(string dummy){
        playNonMovementAnimation = true;
        StartCoroutine(PlayNonMovementAnimation());
    }

*/

    void Start()
    // Start is called before the first frame update    void Start()
    {
        animator = GetComponent<Animator>();
        
        AIDestinationSetterCustom.heroMovementEvent += Animate;
        //InteractWithMeObject.AteMe_Ev += PlayPickupAnimation;
    }

}
