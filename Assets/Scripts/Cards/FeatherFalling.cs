using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherFalling : MonoBehaviour, ICard
{
    public float reducedGravity = 1.905f;

    private Vector3 currentPosition;
    private Vector3 previousPosition;
    private bool ready;

    public void card_preparation(bool status)
    {
        Debug.Log("estatus: " + status);
        if (!status)
        {
            Debug.Log("despreparacion");
            ready = false;
            return; 
        }
        ready = status;
        Debug.Log("Card "+ gameObject.name +" is ready");
        return; 
    }
    public void cast_card()
    {
        if (ready)
        {
            previousPosition = currentPosition;
            currentPosition = transform.position;
    
            if (currentPosition.y < previousPosition.y)
            {
                // Y direction is decreasing and Ctrl key is held down
                Physics.gravity = new Vector3(0, -reducedGravity, 0);
            }
            else
            {
                // Y direction is not decreasing or Ctrl key is not held down
                Physics.gravity = new Vector3(0, -9.81f, 0);
            }
        }    
    }
}

