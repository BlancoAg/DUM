using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtherealEffect : MonoBehaviour, ICard
{
    private bool ready;

    public string tell_description()
    {
        return "Disable the door";
    }

    public void card_preparation(bool status, GameObject handGameObject)
    {
        if (!status)
        {
            ready = false;
            return;
        }
        ready = status;
        return;
    }

    public void cast_card(GameObject handGameObject)
    {
        var player = handGameObject.GetComponent<PlayerMainScript>();
        if (ready)
        {
            Camera mainCamera = handGameObject.GetComponentInChildren<Camera>();

            if (mainCamera != null)
            {
                RaycastHit hit;
                if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
                {
                    GameObject target = hit.transform.gameObject;
                    if (target.CompareTag("Door"))
                    {
                        // Disable the door by disabling its mesh renderer and collider
                        target.GetComponent<MeshRenderer>().enabled = false;
                        target.GetComponent<Collider>().enabled = false;

                        // Play door disable sound
                        //player.GetComponent<Hand>().DoorDisableSound();
                        
                        ready = false;
                    }
                }
            }
            else
            {
                Debug.LogError("Camera not found on handGameObject!");
            }
        }
    }
}
