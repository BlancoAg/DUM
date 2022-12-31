using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpForce = 10.0f;
    public float sprintMultiplier = 2.0f;

    private float verticalRotation = 0;
    private float verticalVelocity = 0;

    private CharacterController characterController;
    private bool isSprinting = false;
    private float jumpTimer = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
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

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded && Input.GetButton("Jump"))
    {
        if (jumpTimer > 0 && jumpTimer < 0.2f)
        {
            // Space key was pressed quickly, reduce jump height
            verticalVelocity = jumpForce * 0.5f;
        }
        else
        {
            // Space key was pressed normally, full jump height
            verticalVelocity = jumpForce;
        }
        jumpTimer = 0;
    }

    jumpTimer += Time.deltaTime;

        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;

        characterController.Move(speed * Time.deltaTime);

        
    }
}
