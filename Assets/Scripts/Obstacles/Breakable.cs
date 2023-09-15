using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public AudioClip breakClip; // Rename the variable to breakClip for clarity
    private bool broken = false;
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If there's no AudioSource component attached, add one.
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the audio clip to the AudioSource component.
        audioSource.clip = breakClip;
    }

    public void Break()
    {
        if (!broken)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            broken = true;

            ParticleSystem particleSystem = transform.GetChild(0).GetComponent<ParticleSystem>();

            if (particleSystem != null)
            {
                particleSystem.Play();
            }

            // Play the break audio clip
            audioSource.Play();
        }
    }
}
