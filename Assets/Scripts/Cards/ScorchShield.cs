using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorchShield : MonoBehaviour, ICard
{
    public bool shielded = false;
    public PlayerMainScript player;
    private bool ready;
    public void card_preparation(bool status)
    {
        Debug.Log("estatus: " + status);
        if (!status)
        {
            Debug.Log("despreparacion");
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
           player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
           if(ready)
           {
              Debug.Log("Card" + gameObject.name + "Played");
              player.shielded = !player.shielded;
              ready = false;
           } 
        }
        
    }
}

