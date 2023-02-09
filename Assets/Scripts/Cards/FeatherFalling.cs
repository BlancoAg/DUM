using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherFalling : MonoBehaviour, ICard
{
    public float slowFallForce = 2.0f;
    public float defaultFallForce = 9.8f;
    private bool ready;
    private Rigidbody playerRigidBody;
    private ConstantForce player;
    private bool ff = false;

    void Start(){
        player =  GameObject.Find("Player").GetComponent<ConstantForce>();
    }

    public void card_preparation(bool status)
    {
        if (!status)
        {
            // var player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
            // player.feather_falling(false);
            Debug.Log("despreparacion");
            if(ff){
            ff = false;
            player.force = player.force - new Vector3(0,8f,0);
            }
            ready = false;
            return;
        }
        ready = status;
        return;
    }
    public void cast_card()
    {
        Debug.Log("cast card");
        Debug.Log(ready);
        Debug.Log(ff);

        // var player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
        if(!ff){
            Debug.Log("FF cast");
            player.force = player.force + new Vector3(0,8f,0);
            ff = true;
        }

    }
}
