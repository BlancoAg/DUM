using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorchShield : MonoBehaviour
{
    public bool shielded = false;
    public PlayerMainScript player;
    // Start is called before the first frame update
private bool ready;
    void prepare_card(){
        Debug.Log("Card "+ gameObject.name +" is ready");
        ready = true;
    }

    void cast_card(){
        player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
        if(ready){
        Debug.Log("Card" + gameObject.name + "Played");
        player.shielded = !player.shielded;
        ready = false;
        }
    }
}

