using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallStance : MonoBehaviour, ICard
{
    public bool ready;

    public void card_preparation(bool status, GameObject handGameObject)
    {
        if (!status)
        {
            ready = false;
            return;
        }
        ready = status;
    }

    public void cast_card(GameObject handGameObject)
    {
<<<<<<< Updated upstream
        // Find the PlayerMainScript component on the GameObject from the Hand script
        var player = handGameObject.GetComponent<PlayerMainScript>();

        if (player != null && ready)
        {
            player.change_size();
            ready = false;
=======
        
        var player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
        if(ready){
        player.change_size();
        ready = false;
>>>>>>> Stashed changes
        }
    }
}
