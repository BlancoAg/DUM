using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneStance : MonoBehaviour, ICard
{
    public bool stoned;
    public float downForce = 5.0f;
    private FirstPersonController firstPersonController;
    private CharacterController characterController;
    public GameObject player;
    private bool ready;
    
    
    void Start()
    {
        stoned = false;
        player = GameObject.Find("Player");
        firstPersonController = player.GetComponent<FirstPersonController>();
        characterController = player.GetComponent<CharacterController>();

    }
    
     public void card_preparation(bool status)
    {
        Debug.Log("estatus: " + status);
        if (!status)
        {
            Debug.Log("despreparacion");
            ready = false;
            return; 
        }
        ready = status;
        Debug.Log("Card "+ gameObject.name +" is ready");
        return; 
    }
    public void cast_card()
    {
        if (ready)
        {
            stoned = !stoned;
            if(stoned)
            {
                firstPersonController.jumpForce = 1.0f;
                if (stoned && !characterController.isGrounded)
                {
                 characterController.Move(Vector3.down * downForce);
                }
            }
            
            else
            {
                firstPersonController.jumpForce = downForce;
            }
        }
    }
}
