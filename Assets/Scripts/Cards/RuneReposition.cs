using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneReposition : MonoBehaviour, ICard
{
    private FirstPersonController firstPersonController;
    private Camera mainCamera;
    private CharacterController characterController;
    private bool ready;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        firstPersonController = player.GetComponent<FirstPersonController>();
        mainCamera = Camera.main;
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
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
            {
                GameObject target = hit.transform.gameObject;
                if (target.CompareTag("Rune"))
                {   
                    Debug.Log("Card " + gameObject.name + " Played");
                    player.GetComponent<CharacterController>().enabled = false;
                    player.GetComponent<FirstPersonController>().enabled = false;
                    player.transform.position = target.transform.position;
                    player.GetComponent<FirstPersonController>().enabled = true;
                    player.GetComponent<CharacterController>().enabled = true;
                    ready = false;
                }
            }
        }
    }
}
