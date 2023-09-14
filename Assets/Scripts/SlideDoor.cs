using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    private bool opening = false;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y == -3){
            opening = false;
        }
        if(opening){
            //Debug.Log(transform.position.y);
            //transform.position.y = transform.position.y - 0.1f;
        }
    }
    void Active(){ 
    opening = true;
    }
}
