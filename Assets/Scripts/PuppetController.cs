using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetController : MonoBehaviour
{
    public bool inControl;
    private Camera puppetCamera;
    private PlayerMovementTutorial playerMovement;
    private ObjectInteraction objectInt;
    private Renderer meshRenderer;
    private GameObject interfaz; 
    private Hand handScript;
    private GameObject gameObject;
    private GameObject cardUpdater;


    void Start()
    {
        puppetCamera = GetComponentInChildren<Camera>();
        playerMovement = GetComponent<PlayerMovementTutorial>();
        objectInt = GetComponent<ObjectInteraction>();
        meshRenderer = GetComponent<Renderer>();
        interfaz = transform.Find("Interfaz").gameObject; 
        handScript = GetComponent<Hand>();
        gameObject = transform.Find("GameObject").gameObject;
        cardUpdater = transform.Find("CardInHandUpdater").gameObject;

        ToggleControl(inControl);
    }

    public void ToggleControl(bool control)
    {
        inControl = control;
        objectInt.enabled = control;

        // Enable/disable the camera
        if (puppetCamera != null)
        {
            puppetCamera.enabled = control;
        }

        // Enable/disable the movement script
        if (playerMovement != null)
        {
            playerMovement.enabled = control;
        }

        // Enable/disable the mesh renderer (if it exists)
        if (meshRenderer != null)
        {
            meshRenderer.enabled = !control;
        }

        // Toggle the visibility of the Interfaz GameObject
        if (interfaz != null)
        {
            interfaz.SetActive(control);
        }

        // Toggle the Hand script
        if (handScript != null)
        {
            handScript.enabled = control;
        }

        // Toggle the GameObject element
        if (gameObject != null)
        {
            gameObject.SetActive(control);
        }

        // Toggle the CardInHandUpdater element
        if (cardUpdater != null)
        {
            cardUpdater.SetActive(control);
        }
    }
}