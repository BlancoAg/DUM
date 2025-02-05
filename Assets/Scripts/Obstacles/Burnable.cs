using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burnable : MonoBehaviour
{
    private bool isInside = false;
    private float stayTime = 0f;
    public float timeThreshold = 3f;

    // When an object enters the prefab's collider
    private void OnTriggerEnter(Collider other)
    {
        isInside = true;
    }

    // When the object stays in the prefab's collider
    private void OnTriggerStay(Collider other)
    {
        if (isInside)
        {
            stayTime += Time.deltaTime;

            if (stayTime >= timeThreshold)
            {
                DisableChildren();
            }
        }
    }

    // When the object leaves the prefab's collider
    private void OnTriggerExit(Collider other)
    {
        isInside = false;
        stayTime = 0f;
    }

    // Disable all children of the prefab
    private void DisableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
