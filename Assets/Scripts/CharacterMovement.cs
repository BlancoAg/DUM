using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion.Fluid;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float jumpForce = 5f;
    public float sprintMultiplier = 2.0f;
    public LayerMask groundLayers;

    private float verticalRotation = 0f;
    private Rigidbody rb;
    private bool isJumping;
    private bool isSprinting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Handle rotation
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Handle movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

         if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            forwardSpeed *= sprintMultiplier;
            sideSpeed *= sprintMultiplier;
        }
        else
        {
            isSprinting = false;
        }

        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
        speed = transform.rotation * speed;

        // Check if the player is on the ground before jumping
        if (Physics.Raycast(transform.position, Vector3.down, 0.7f, groundLayers))
        {
            isJumping = false;
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isJumping = true;
            }
        }

        if (!isJumping)
            rb.MovePosition(transform.position + speed * Time.deltaTime);
    }
}

