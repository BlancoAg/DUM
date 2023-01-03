using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorch_Shield : MonoBehaviour
{
    bool shielded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    if(Input.GetKey("t")){
        Debug.Log("t");
        shielded = true;
    }else{
       shielded = false;
    }
    
    if(shielded){
        Debug.Log("shielded");
    }else{
       Debug.Log("Normal");
    }
    }
}
