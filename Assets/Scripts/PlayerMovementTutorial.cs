using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovementTutorial : MonoBehaviour
{
    private GameObject player;
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public float mouseSensitivity = 2.0f;
    private float verticalRotation = 0;
    public bool readyToJump;

    public bool readyToDoubleJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Footstep Sounds")]
    public AudioClip[] footstepSounds;

    private AudioSource audioSource;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;


    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        player = GameObject.Find("Player");
        playerHeight = player.transform.localScale.y;
        readyToJump = true;
        readyToDoubleJump = true;

        //mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //footsteps
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1.0f; // Set spatial blend to 3D for positional audio.
    }

    private void Update()
    {
        // ground check
        playerHeight = player.transform.localScale.y;
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        //mouse look
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
        if (grounded && readyToJump)
        {
            readyToDoubleJump = true;
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

            // Check if the player is moving (horizontal or vertical input is not zero)
            if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
            {
                // Play a random footstep sound
                PlayRandomFootstepSound();
            }
        }

        // in air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }


    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    public void ResetJump()
    {
        //Debug.Log("ResetJump");
        readyToJump = true;
        if (grounded)
        {
            readyToDoubleJump = true;
        }
    }

    private bool isPlayingFootstep = false; // Flag to track if a footstep sound is currently playing

    private void PlayRandomFootstepSound()
    {
        if (!isPlayingFootstep && footstepSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepSounds.Length);
            AudioClip randomFootstepSound = footstepSounds[randomIndex];
            StartCoroutine(PlayFootstepAndWait(randomFootstepSound));
        }
    }

    private IEnumerator PlayFootstepAndWait(AudioClip footstepSound)
    {
        isPlayingFootstep = true;
        audioSource.PlayOneShot(footstepSound);

        // Wait for the length of the footstep sound clip before allowing another footstep to be played
        yield return new WaitForSeconds(footstepSound.length);

        isPlayingFootstep = false;
    }

}