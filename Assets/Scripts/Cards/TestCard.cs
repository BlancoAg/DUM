using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCard : MonoBehaviour, ICard
{
    private bool status;
    private bool ready;

    public void card_preparation(bool status){
    Debug.Log("estatus: " + status);
    if(!status){
        Debug.Log("despreparacion");
        ready = false;

        // bla bla bla 
        
        return; 
    }

        ready = status;
        Debug.Log("Card "+ gameObject.name +" is ready");
         //bla bla bla 
        return;
       
    }

    public void cast_card(){
        if(ready){
        Debug.Log("Card " + gameObject.name + " Played");
        //bla bla bla
        ready = false;
        }
    }
}
