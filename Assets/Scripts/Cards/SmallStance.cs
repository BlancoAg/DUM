using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SmallStance : MonoBehaviour, ICard
{   
    public bool ready;
    //public bool player.big = true;
    //public bool player.biggering = false;
    //public bool player.shrinking = false;

    // Start is called before the first frame update
    public void card_preparation(bool status){
        Debug.Log("estatus: " + status);
        if (!status)
        {
            //Debug.Log("despreparacion");
            ready = false;
            return; 
        }
        ready = status;
        Debug.Log("Card "+ gameObject.name +" is ready");
        return; 
    }

    public void cast_card()
    {
        var player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
        if(ready){
        player.GetComponent<Hand>().play_sound();
        player.change_size();
        ready = false;
        }
    }

}
