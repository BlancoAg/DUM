using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_card : MonoBehaviour
{
    private bool ready;
    void prepare_card(){
        Debug.Log("Card "+ gameObject.name +" is ready");
        ready = true;
    }

    void cast_card(){
        if(ready){
        Debug.Log("Card" + gameObject.name + "Played");
        ready = false;
        }
    }

}
