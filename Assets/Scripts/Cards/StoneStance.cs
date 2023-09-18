using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneStance : MonoBehaviour, ICard
{
    public bool stoned = false;
    private bool ready;
    public GameObject StoneStanceIcon;

    public float weight;

    public void card_preparation(bool status)
    {
        ////Debug.Log("estatus: " + status);
        if (!status)
        {
            ////Debug.Log("despreparacion");
            var player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
            if(player.stoned){
            player.stone_status(false,weight);
            }
            ready = false;
            return; 
        }
        ready = status;
        ////Debug.Log("Card "+ gameObject.name +" is ready");
        return; 
    }

    public void cast_card()
    {      
        if(ready)
        {
           var player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
           if(ready)
           {
              ////Debug.Log("Card" + gameObject.name + "Played");
              //player.shielded = !player.shielded;
              player.GetComponent<Hand>().PlaySound();
              player.stone_status(true,weight);
              ready = false;
           } 
        }
    }
}