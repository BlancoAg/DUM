using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorchShield : MonoBehaviour, ICard
{
    public bool shielded = false;
    private bool ready;
    public GameObject ScorchShieldIcon;

    private bool isHeld = false; // Track if the left mouse button is being held

    public string tell_description()
    {
        return "test";
    }

    public void card_preparation(bool status, GameObject handGameObject)
    {
        // This method is now unused, but it must remain because of the ICard interface
    }

    public void cast_card(GameObject handGameObject)
    {
        var player = handGameObject.GetComponent<PlayerMainScript>();
        
        if (!isHeld)
        {
            // If the left mouse button is clicked
            player.shield_status(true);
            isHeld = true;
        }
        else
        {
            // If the left mouse button is held
            player.shield_status(false);
            isHeld = false;
        }
    }

    void Update()
    {
        if (isHeld && Input.GetMouseButton(1))
        {
            var player = GetComponentInParent<PlayerMainScript>();
            if (player != null)
            {
                player.shield_status(true);
                GlobalVariables.on_fire = true;
            }
        }
        else if (isHeld && !Input.GetMouseButton(1))
        {
            var player = GetComponentInParent<PlayerMainScript>();
            if (player != null)
            {
                player.shield_status(false);
                GlobalVariables.on_fire = false;
            }
            isHeld = false;
        }
    }
}
