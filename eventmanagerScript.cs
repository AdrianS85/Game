using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class eventmanagerScript : MonoBehaviour
{
    public scriptableObjectSpawner so;
    public float testRotation;
    GameObject player_ref;



    ///////////////////////////
    // HERO MOVEMENT MENAGER //
    [SerializeField]
    private Vector2 previousPlayerPosition;
    [SerializeField]
    private string playerDirection;
    private string previousPlayerDirection;
    [SerializeField]
    private bool doesHeMove__;
    [SerializeField]
    private float velocityBufferForChangingMovementDir = 0.1f; // this will need to ba changed based on scriptable object velocity setter



    // Tutaj jitter może być spowodowany tym, że 45 stopni łatwo może przeskoczyc między 44.9 a 45. Zróbmy może tak, że weźmy poprawkę na obliczanie kierunku ruchu biorąc pod uwagę poprzedni kierunek ruchu. MOże tak: jeśli już idzie w którąś stronę, to zmieńmy tą stronę tylko jak kierunek ruchu wyraźnie się zmieni




    void heroMovementToAnimation(bool doesHeMove, Vector3 currentVelocity)
    {
        doesHeMove__ = doesHeMove;

        if (doesHeMove == true) 
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

            } else if (aVelX < aVelY & velY < 0)
            {
                    playerDirection = "d";

            } else if (aVelX > aVelY & velX > 0)
            {
                    playerDirection = "r"; 

            } else if (aVelX > aVelY & velX < 0)
            {
                    playerDirection = "l";

            } else
            {
                playerDirection = previousPlayerDirection;
            }
        }

        previousPlayerDirection = playerDirection;

    }



    public delegate void heroMovementEMBroadcastDelegate(bool doesHeMove_, string direction_);
    public static event heroMovementEMBroadcastDelegate heroMovementEMBroadcastEvent;

    // HERO MOVEMENT MENAGER //
    ///////////////////////////






    ////////////////////////
    // ITEM USAGE MENAGER //
    [SerializeField]
    private string item_name; 
    [SerializeField]
    private int button_used;
    [SerializeField]
    private bool didIJustInteractedWithItem = false;
    void RespondToInteractionWithItem(string item_name_, int button_used_)
    {
        item_name = item_name_;
        button_used = button_used_;
        didIJustInteractedWithItem = true;
    } // I will probably need to turn off the movement order after picking up the item


    public delegate void ateMeEMBroadcastDelegate(string objectName, int button_, bool didIJustInteractedWithItem);
    public static event ateMeEMBroadcastDelegate ateMeEMBroadcastEvent;

    // ITEM USAGE MENAGER //
    ////////////////////////




    void Start()
    {
        player_ref = GameObject.FindGameObjectWithTag("Player");
        
        AIDestinationSetterCustom.heroMovementEvent += heroMovementToAnimation;


        EatMeBehavior.AteMeEvent += RespondToInteractionWithItem;
    }

    // Update is called once per frame
    void Update()
    {


        heroMovementEMBroadcastEvent(doesHeMove__, playerDirection);
        
        

        if (didIJustInteractedWithItem == true)
        {
            didIJustInteractedWithItem = false; // this should be after broadcast I think?
            
            ateMeEMBroadcastEvent(item_name, button_used, didIJustInteractedWithItem);
        }
        

    }
}








/*
    void heroMovementToAnimation(bool doesHeMove, Vector3 currentPosition)
    {
        Vector2 CurrentMinusPreviousPosition;
        
        CurrentMinusPreviousPosition = new Vector2((currentPosition.x - previousPlayerPosition.x) * 1000, (currentPosition.y - previousPlayerPosition.y)*1000);
        
        doesHeMove__ = doesHeMove;


        if (doesHeMove == true) 
        {  
            
            if (Mathf.Abs(CurrentMinusPreviousPosition.x) < Mathf.Abs(CurrentMinusPreviousPosition.y))
            {
                if (CurrentMinusPreviousPosition.y > 0)
                {
                    playerDirection = "u"; 
                } else if (CurrentMinusPreviousPosition.y < 0)
                {
                    playerDirection = "d";
                }

            } else if (Mathf.Abs(CurrentMinusPreviousPosition.x) > Mathf.Abs(CurrentMinusPreviousPosition.y))
            {
                if (CurrentMinusPreviousPosition.x > 0)
                {
                    playerDirection = "r"; 
                } else if (CurrentMinusPreviousPosition.x < 0)
                {
                    playerDirection = "l";
                }
            } else
            {
                playerDirection = previousPlayerDirection;
            }

        }

        previousPlayerDirection = playerDirection;

        previousPlayerPosition = new Vector2(currentPosition.x, currentPosition.y);
    }
    
    
    
    
    
    
        ///////////////////////////
    // HERO MOVEMENT MENAGER //
    [SerializeField]
    private Vector2 previousPlayerPosition;
    [SerializeField]
    private string playerDirection;
    private string previousPlayerDirection;
    [SerializeField]
    private bool doesHeMove__;


    // Tutaj jitter może być spowodowany tym, że 45 stopni łatwo może przeskoczyc między 44.9 a 45. Zróbmy może tak, że weźmy poprawkę na obliczanie kierunku ruchu biorąc pod uwagę poprzedni kierunek ruchu. MOże tak: jeśli już idzie w którąś stronę, to zmieńmy tą stronę tylko jak kierunek ruchu wyraźnie się zmieni
    void heroMovementToAnimation(bool doesHeMove, Vector3 currentVelocity)
    {
        doesHeMove__ = doesHeMove;

        if (doesHeMove == true) 
        {  
            
            if (Mathf.Abs(currentVelocity.x) < Mathf.Abs(currentVelocity.y))
            {
                if (currentVelocity.y > 0)
                {
                    playerDirection = "u"; 
                } else if (currentVelocity.y < 0)
                {
                    playerDirection = "d";
                }

            } else if (Mathf.Abs(currentVelocity.x) > Mathf.Abs(currentVelocity.y))
            {
                if (currentVelocity.x > 0)
                {
                    playerDirection = "r"; 
                } else if (currentVelocity.x < 0)
                {
                    playerDirection = "l";
                }
            } else
            {
                playerDirection = previousPlayerDirection;
            }
        }

        previousPlayerDirection = playerDirection;

    }



    public delegate void heroMovementEMBroadcastDelegate(bool doesHeMove_, string direction_);
    public static event heroMovementEMBroadcastDelegate heroMovementEMBroadcastEvent;

    // HERO MOVEMENT MENAGER //
    ///////////////////////////
    
    
    
    
    
    
    
    
    */