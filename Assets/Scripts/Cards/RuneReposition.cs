using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneReposition : MonoBehaviour, ICard
{
    private bool ready; 

    public void card_preparation(bool status, GameObject handGameObject)
    {
        //Debug.Log("estatus: " + status);
        if (!status)
        {
            //Debug.Log("despreparacion");
            ready = false;
            return; 
        }
        ready = status;
        //Debug.Log("Card "+ gameObject.name +" is ready");
        return; 
    }

    public void cast_card(GameObject handGameObject)
{
    var player = handGameObject.GetComponent<PlayerMainScript>();
    if (ready)
    {
        // Get the camera from handGameObject
        Camera mainCamera = handGameObject.GetComponentInChildren<Camera>();

        if (mainCamera != null) // Check if a camera component was found
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
            {
                GameObject target = hit.transform.gameObject;
                if (target.CompareTag("Rune"))
                {
                    // Move the player to the position of the target
                    player.transform.position = target.gameObject.transform.position;
                    player.GetComponent<Hand>().RuneSound();
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
