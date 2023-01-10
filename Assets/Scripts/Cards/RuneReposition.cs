using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneReposition : MonoBehaviour
{
    private FirstPersonController firstPersonController;
    private Camera mainCamera;
    private CharacterController characterController;
    private bool ready ;
    void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
        mainCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
    }

    public void card_preparation(bool status){
    Debug.Log("estatus: " + status);
    if(!status){
        Debug.Log("despreparacion");
        ready = false;

        // bla bla bla 
        
        return; 
    }

        ready = status;
        Debug.Log("Card "+ gameObject.name +" is ready");
         //bla bla bla 
        return;
       
    }

    public void cast_card(){
        if(ready)
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
            {
                GameObject target = hit.transform.gameObject;
                if (target.CompareTag("Rune"))
                {   

                    characterController.enabled = false;
                    firstPersonController.enabled = false;
                    transform.position = target.transform.position;
                    firstPersonController.enabled = true;
                    characterController.enabled = true;
                    ready = false;
                }
            }
        }
    }
}
