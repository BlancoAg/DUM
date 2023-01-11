using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetController : MonoBehaviour
{
    public GameObject player; 
    public GameObject puppet; 
    public Camera playerCamera; 
    public Camera puppetCamera; 

    void Start()
    {
        // Make sure both cameras are enabled
        playerCamera.enabled = true;
        puppetCamera.enabled = false;
    }

    void Update()
    {
        // Check if player clicks on puppet
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == puppet)
                {
                    // Disable player camera and enable puppet camera
                    playerCamera.enabled = false;
                    puppetCamera.enabled = true;
                    // Disable player's movement script
                    player.GetComponent<FirstPersonController>().enabled = false;

                    // Enable puppet's movement script
                    puppet.GetComponent<FirstPersonController>().enabled = true;
                }
            }
        }
    }
}

