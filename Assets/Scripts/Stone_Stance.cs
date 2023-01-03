using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Stance : MonoBehaviour
{
    bool stoned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    if(Input.GetKey("r")){
        Debug.Log("r");
        stoned = true;
    }else{
       stoned = false;
    }
    
    if(stoned){
        Debug.Log("Stoned");
    }else{
       Debug.Log("Normal");
    }
    }
}