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
    public bool jumping;
    public bool readyToDoubleJump;

    // Ladder climbing variables
    public bool isClimbing = false;
    public float climbSpeed = 5.0f;
    private Transform currentLadder;
    private float verticalIn;
    private float horizontalIn;

    public GameObject feet;
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
    public float waterMovementSpeed = 5.0f;
    private bool inWater = false;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;


    Vector3 moveDirection;

    Rigidbody rb;

    private Animator CameraAnimation;
    private void Start()
    {
        CameraAnimation = GameObject.Find("Main Camera").GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        player = GameObject.Find("Player");
        
        playerHeight = 0.01f;
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
        if (GlobalVariables.character_small == false){
            moveSpeed = 7.0f;
            jumpForce = 7.0f;
        }else
        {
            moveSpeed = 1.5f;
            jumpForce = 3.0f;
        }
        if (!isClimbing && !inWater)
        {
        // ground check
        // playerHeight = player.transform.localScale.y;
        
        grounded = Physics.Raycast(feet.transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
            if(!grounded){
                jumping = true;
            }else if(jumping){
                jumping = false;
                CameraAnimation.SetTrigger("Landing");
            }


            MyInput();
            SpeedControl();


            // handle drag
            if (grounded){
                rb.drag = groundDrag;
                //CameraAnimation.SetBool("Landing", true);


            }else
                rb.drag = 0;

            HandleMouseLook();
        }
        else if (isClimbing)
        {
            // Handle ladder climbing
            HandleLadderClimbing();
        }
        else if (inWater)
        {
            // Handle movement and rotation when in water

            // Reset movement input
            ResetMovementInput();
            // Movement
            HandleWaterMovement();
            // Mouse look
            HandleMouseLook();
        }

    }

    // Additional methods for ladder climbing

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            inWater = true;
        }
        else if (other.CompareTag("Ladder"))
        {
            // Check if the player enters a ladder's collision box
            isClimbing = true;
            currentLadder = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            inWater = false;
        }
        else if (other.CompareTag("Ladder"))
        {
            // Check if the player exits the ladder's collision box
            isClimbing = false;
            currentLadder = null;
        }
    }

    private void HandleLadderClimbing()
    {
        // Handle ladder climbing input
        verticalIn = Input.GetAxis("Vertical");
        horizontalIn = Input.GetAxis("Horizontal");

        // Move the player up and down the ladder
        Vector3 climbDirection = currentLadder.up * verticalIn;
        GetComponent<Rigidbody>().velocity = climbDirection * climbSpeed;

        // Handle side movement while climbing
        Vector3 sideMovement = transform.right * horizontalIn;
        GetComponent<Rigidbody>().velocity += sideMovement * climbSpeed;

        // Handle mouse look
        HandleMouseLook();
    }


    private void HandleWaterMovement()
    {
        float forwardSpeed = Input.GetAxis("Vertical") * waterMovementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * waterMovementSpeed;

        Vector3 movement = new Vector3(sideSpeed, 0, forwardSpeed);
        movement = transform.rotation * movement;

        transform.position += movement * Time.deltaTime;

        // Mouse rotation remains the same as in the Update() method
        HandleMouseLook();
    }

    private void HandleMouseLook()
    {
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    private void ResetMovementInput()
    {
        horizontalInput = 0f;
        verticalInput = 0f;
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
                CameraAnimation.SetBool("Walking", true);
                PlayRandomFootstepSound();
            }
            else{
                CameraAnimation.SetBool("Walking", false);
            }
            //
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