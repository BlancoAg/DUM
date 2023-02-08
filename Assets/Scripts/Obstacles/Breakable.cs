using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    private bool broken = false;
    private void OnTriggerEnter(Collider other)
    {   
        //ParticleSystem particleSystem = GameObject.Find("Shatter").GetComponent<ParticleSystem>();
        if (other.GetComponent<PlayerMainScript>().falling == true && !broken)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            broken = true;
        
        // Find the particle system component in the scene
        ParticleSystem particleSystem = GameObject.Find("Shatter").GetComponent<ParticleSystem>();

        // Check if the particle system is not null
        if (particleSystem != null)
        {
            // Play the particle system
            particleSystem.Play();
        }
        }
    }
}


