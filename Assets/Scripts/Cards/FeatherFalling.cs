using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherFalling : MonoBehaviour, ICard
{
    public float slowFallForce = 2.0f;
    public float defaultFallForce = 9.8f;
    private bool ready;
    private ConstantForce player;
    private bool ff = false;

    public void card_preparation(bool status, GameObject handGameObject)
    {
        if (!status)
        {
            var player = handGameObject.GetComponent<ConstantForce>();
            // var player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
            // player.feather_falling(false);
            //Debug.Log("despreparacion");
            if(ff){
            ff = false;
            player.force = player.force - new Vector3(0,4f,0);
            }
            ready = false;
            return;
        }
        ready = status;
        return;
    }
    public void cast_card(GameObject handGameObject)
    {
        //Debug.Log("cast card");
        //Debug.Log(ready);
        //Debug.Log(ff);

        var player = handGameObject.GetComponent<ConstantForce>();
        if(!ff){
            //Debug.Log("FF cast");
            player.force = player.force + new Vector3(0,4f,0);
            ff = true;
        }

    }
}
