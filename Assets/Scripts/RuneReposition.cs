using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneReposition : MonoBehaviour
{
    private FirstPersonController firstPersonController;
    private Camera mainCamera;

    void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
            {
                GameObject target = hit.transform.gameObject;
                if (target.CompareTag("Rune"))
                {
                    firstPersonController.enabled = false;
                    transform.position = target.transform.position;
                    firstPersonController.enabled = true;
                }
            }
        }
    }
}

