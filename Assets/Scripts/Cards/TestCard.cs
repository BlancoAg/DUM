using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCard : MonoBehaviour
{
    private bool ready;
    public void prepare_card(){
        Debug.Log("Card "+ gameObject.name +" is ready");
        ready = true;
    }

    public void cast_card(){
        if(ready){
        Debug.Log("Card" + gameObject.name + "Played");
        ready = false;
        }
    }

}
