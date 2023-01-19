using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion.Fluid;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 movement = new Vector3(sideSpeed, 0, forwardSpeed);
        movement = transform.rotation * movement;

        transform.position += movement * Time.deltaTime;

        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        float rotUpDown = Input.GetAxis("Mouse Y") * mouseSensitivity;
        Camera.main.transform.Rotate(-rotUpDown, 0, 0);
    }
}

