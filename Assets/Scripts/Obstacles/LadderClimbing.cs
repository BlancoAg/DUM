using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimbing : MonoBehaviour
{
    private bool isClimbing = false;
    private Transform currentLadder;

    private float verticalInput;
    private float horizontalInput;
    private float mouseSensitivity = 2.0f;
    private float verticalRotation = 0.0f;

    private void Update()
    {
        if (isClimbing)
        {
            // Handle ladder climbing input
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            // Move the player up and down the ladder
            Vector3 climbDirection = currentLadder.up * verticalInput;
            GetComponent<Rigidbody>().velocity = climbDirection * 5f;

            // Handle side movement while climbing
            Vector3 sideMovement = transform.right * horizontalInput;
            GetComponent<Rigidbody>().velocity += sideMovement * 5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            // Check if the player enters a ladder's collision box
            isClimbing = true;
            currentLadder = other.transform;

            // Disable the player's regular movement
            GetComponent<PlayerMovementTutorial>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            // Check if the player exits the ladder's collision box
            isClimbing = false;
            currentLadder = null;

            // Enable the player's regular movement
            GetComponent<PlayerMovementTutorial>().enabled = true;
        }
    }
}
