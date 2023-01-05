using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public Damageable damageable;
    public float fallDamageThreshold = 10.0f; // The minimum fall height for fall damage to be applied
    public float fallDamageMultiplier = 2.0f; // The amount of damage to apply per unit of fall distance above the threshold
    private CharacterController characterController;

    private float lastGroundY = 0.0f; // The y-position of the ground when the player was last on the ground

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        lastGroundY = transform.position.y;
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // Update the last ground y-position if the player is on the ground
            lastGroundY = transform.position.y;
        }
        else
        {
            // Calculate the fall distance
            float fallDistance = transform.position.y - lastGroundY;

            // Check if the fall distance is above the threshold
            if (fallDistance > fallDamageThreshold)
            {
                // Calculate the fall damage
                float fallDamage = (fallDistance - fallDamageThreshold) * fallDamageMultiplier;

                // Apply the fall damage to the player
                damageable.ApplyDamage(fallDamage);
            }
        }
    }
}


