using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetController : MonoBehaviour
{
    public bool inControl = true; // Added inControl variable
    private Camera puppetCamera;
    private PlayerMovementTutorial playerMovement;
    private Renderer meshRenderer;

    void Start()
    {
        puppetCamera = GetComponentInChildren<Camera>();
        playerMovement = GetComponent<PlayerMovementTutorial>();
        meshRenderer = GetComponent<Renderer>();

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
        if (Input.GetMouseButtonDown(0))
        {
            Camera cameraComponent = GetComponentInChildren<Camera>();
            Ray ray = cameraComponent.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Puppet") || hit.collider.CompareTag("Player"))
                {
                    ToggleControl(!inControl);
                    hit.collider.gameObject.GetComponent<PuppetController>().ToggleControl(true);
                }
            }
        }
    }

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
    }
}
