using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    private bool broken = false;
    public void Break()
    {   
        //ParticleSystem particleSystem = GameObject.Find("Shatter").GetComponent<ParticleSystem>();
        if (!broken)
        {
            //transform.GetChild(0).gameObject.SetActive(false);
            //Debug.Log(gameObject.name);
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            broken = true;
        
        // Find the particle system component in the scene
        ParticleSystem particleSystem = transform.GetChild(0).GetComponent<ParticleSystem>();

        // Check if the particle system is not null
        if (particleSystem != null)
        {
            // Play the particle system
            particleSystem.Play();
        }
        }
    }
}


