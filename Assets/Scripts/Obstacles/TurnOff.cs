using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour, IActivate
{
    public bool turned = true;

    void Update()
    {
        // Check the value of 'turned' and enable/disable MeshRenderer and BoxCollider accordingly
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        BoxCollider boxCollider = GetComponent<BoxCollider>();

        if (meshRenderer != null && boxCollider != null)
        {
            if (turned)
            {
                meshRenderer.enabled = true;
                boxCollider.enabled = true;
            }
            else
            {
                meshRenderer.enabled = false;
                boxCollider.enabled = false;
            }
        }
    }

    public void Active()
    {
        Debug.Log("Active");
        turned = !turned;
    }

}
