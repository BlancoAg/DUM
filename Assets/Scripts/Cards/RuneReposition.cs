using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneReposition : MonoBehaviour, ICard
{
    private bool ready; 
    public string tell_description() {
        return  "test";
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
            // Get the camera from handGameObject
            Camera mainCamera = handGameObject.GetComponentInChildren<Camera>();

            if (mainCamera != null) // Check if a camera component was found
            {
                RaycastHit hit;
              if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, Mathf.Infinity, ~LayerMask.GetMask("Player")))
{
    // Código a ejecutar si el Raycast impacta algo que no tenga el tag 'Player'
}

                {
                    GameObject target = hit.transform.gameObject;
                    Debug.Log(target.tag);
                    if (target.CompareTag("Rune"))
                    {
                        // Buscar el objeto hijo "TP_location"
                        Transform tpLocation = target.transform.Find("TP_location");
                        
                        if (tpLocation != null) // Si el objeto "TP_location" fue encontrado
                        {
                            // Mover al jugador a la posición del objeto hijo "TP_location"
                            player.transform.position = tpLocation.position;
                            player.GetComponent<Hand>().RuneSound();
                            ready = false;
                        }
                        else
                        {
                            Debug.LogError("TP_location not found on the rune!");
                        }
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

