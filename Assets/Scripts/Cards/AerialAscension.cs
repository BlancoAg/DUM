using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialAscension : MonoBehaviour, ICard
{

    private bool ready;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void card_preparation(bool status)
    {
        Debug.Log("estatus: " + status);
        if (!status)
        {
            Debug.Log("despreparacion");
            var player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
            player.shield_status(false);
            ready = false;
            return; 
        }
        ready = status;
        return; 
    }

    public void cast_card()
    {
        var player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
           if(ready)
           {
              //player.shielded = !player.shielded;
              player.AerialAscension();
              ready = false;
           }
    }
}
