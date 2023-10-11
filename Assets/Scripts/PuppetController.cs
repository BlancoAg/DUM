using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetController : MonoBehaviour
{
    public bool inControl = false;
    private Camera puppetCamera;
    private PlayerMovementTutorial playerMovement;
    private Renderer meshRenderer;
    private GameObject interfaz; // Reference to the Interfaz GameObject.
    private Hand handScript;
    private GameObject gameObject;
    private GameObject cardUpdater;

    // Variables to track control transfer
    private bool isTransferringControl = false;
    private PuppetController targetPuppet;

    void Start()
    {
        puppetCamera = GetComponentInChildren<Camera>();
        playerMovement = GetComponent<PlayerMovementTutorial>();
        meshRenderer = GetComponent<Renderer>();
        interfaz = transform.Find("Interfaz").gameObject; // Find and store the Interfaz GameObject.
        handScript = GetComponent<Hand>();
        gameObject = transform.Find("GameObject").gameObject;
        cardUpdater = transform.Find("CardInHandUpdater").gameObject;

        if (puppetCamera != null)
        {
            puppetCamera.enabled = true;
        }
        else
        {
            Debug.LogWarning("No Camera component found on this GameObject or its children.");
        }

        ToggleControl(inControl);
    }

    void Update()
    {
        if (!isTransferringControl && Input.GetMouseButtonDown(0))
        {
            Camera cameraComponent = GetComponentInChildren<Camera>();
            Ray ray = cameraComponent.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Puppet") || hit.collider.CompareTag("Player"))
                {
                    // Store the target puppet for control transfer
                    targetPuppet = hit.collider.gameObject.GetComponent<PuppetController>();
                    ToggleControl(false);
                    targetPuppet.ToggleControl(true);
                    // Start the control transfer coroutine
                    //StartCoroutine(TransferControlAfterDelay(1.0f));
                }
            }
        }
    }

    // IEnumerator TransferControlAfterDelay(float delay)
    // {
    //     isTransferringControl = true;

    //     // Wait for the specified delay
    //     yield return new WaitForSeconds(delay);

    //     // Transfer control to the target puppet
    //     ToggleControl(false);
    //     targetPuppet.ToggleControl(true);

    //     // Reset variables
    //     targetPuppet = null;
    //     isTransferringControl = false;
    // }

    void ToggleControl(bool control)
    {
        inControl = control;

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
