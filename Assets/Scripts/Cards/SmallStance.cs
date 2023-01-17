using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SmallStance : MonoBehaviour, ICard
{   
    public bool ready;
    //public bool player.big = true;
    //public bool player.biggering = false;
    //public bool player.shrinking = false;
    public GameObject Player;
    public PlayerMainScript player;
    public float smallsize;
    public float bigsize;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Debug.Log(Player.name);
        player = Player.GetComponent<PlayerMainScript>();
    }
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
        if(ready)
        player.change_size();
        ready = false;

    }

}
