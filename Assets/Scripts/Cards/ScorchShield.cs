using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorchShield : MonoBehaviour, ICard
{
    public bool shielded = false;
    private bool ready;
    public GameObject ScorchShieldIcon;
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
        Debug.Log("Card "+ gameObject.name +" is ready");
        return; 
    }

    public void cast_card()
    {      
        if(ready)
        {
           var player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
           if(ready)
           {
              Debug.Log("Card" + gameObject.name + "Played");
              //player.shielded = !player.shielded;
              player.shield_status(true);
              ready = false;
           } 
        }
    }
}