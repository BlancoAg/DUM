using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetController : MonoBehaviour
{
    public GameObject player;  
    public Camera playerCamera; 

    void Start()
    {
        // Make sure both cameras are enabled
        playerCamera.enabled = true;
        //Search "Puppet" objects
        GameObject[] puppetObjects = GameObject.FindGameObjectsWithTag("Puppet");

        // Disable the cameras of all the found objects
        foreach (GameObject puppet in puppetObjects)
        {
            puppet.GetComponentInChildren<Camera>().enabled = false;
        }
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
                if (hit.collider.tag == "Puppet")
                {
                    // Disable player camera and enable puppets cameras
                    playerCamera.enabled = false;
                    hit.collider.gameObject.GetComponentInChildren<Camera>().enabled = true;
                    // Disable player's movement script
                    player.GetComponent<FirstPersonController>().enabled = false;

                    // Enable puppet's movement script
                    hit.collider.gameObject.GetComponent<FirstPersonController>().enabled = true;
                }
            }
        }
    }
}

