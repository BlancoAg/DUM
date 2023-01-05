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
    private StoneStance stoneStance;
    private bool isSprinting = false;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        stoneStance = GetComponent<StoneStance>();
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
            if (stoneStance.stoned)
            {

               verticalVelocity = 1.0f;
            }
            else
            {
            verticalVelocity = jumpForce;
            }
        }

        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;

        characterController.Move(speed * Time.deltaTime);
    }
}
