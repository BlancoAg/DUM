using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    //private PlayerMainScript player;

    private void Start() 
    {
        //player = GetComponent<PlayerMainScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.GetComponent<PlayerMainScript>().falling == true)
        {
        //    Destroy(transform.parent.gameObject);
        }
    }
}

