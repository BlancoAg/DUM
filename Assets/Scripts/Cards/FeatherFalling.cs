using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherFalling : MonoBehaviour, ICard
{
    public float slowFallForce = 2.0f;
    public float defaultFallForce = 9.8f;
    private bool ready;
    private Rigidbody playerRigidBody;
    
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    public void card_preparation(bool status)
    {
        if (!status)
        {
            var player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
            player.feather_falling(false);
            ready = false;
            return; 
        }
        ready = status;
        return; 
    }
    public void cast_card()
    {
        var player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
        if (ready)
        {
            player.feather_falling(true);
            ready = false;
        }
        
    }   
}
