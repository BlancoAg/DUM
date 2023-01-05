using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneStance : MonoBehaviour
{
    public bool stoned = false;
    public float downForce = 5.0f;
    private FirstPersonController firstPersonController;
    private CharacterController characterController;
    
    
    void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
        characterController = GetComponent<CharacterController>();

    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            stoned = !stoned;
        }

        if (stoned && !characterController.isGrounded)
        {
            characterController.Move(Vector3.down * downForce);
        }
    }
}
