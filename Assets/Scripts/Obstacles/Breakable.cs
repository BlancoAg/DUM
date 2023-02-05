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
        ParticleSystem particleSystem = GameObject.Find("Shatter").GetComponent<ParticleSystem>();
        if (other.GetComponent<PlayerMainScript>().falling == true)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            // Find the particle system component in the scene

        // Check if the particle system is not null
            if (particleSystem != null)
        {
            // Play the particle system
            particleSystem.Play();
        }
        }
    }
}

