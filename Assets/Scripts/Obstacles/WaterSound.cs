using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSound : MonoBehaviour
{
    public AudioClip soundToPlay;
    private AudioSource audioSource;
    private bool isInside = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundToPlay;
        audioSource.loop = true; // Set the audio source to loop the sound
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInside)
        {
            audioSource.Play(); // Start playing the sound when the player enters
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInside)
        {
            audioSource.Stop(); // Stop the sound when the player exits
            isInside = false;
        }
    }
}
