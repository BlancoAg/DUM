using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherFalling : MonoBehaviour, ICard
{
    public float reducedGravity = 2.905f;

    private Vector3 currentPosition;
    private Vector3 previousPosition;
    private bool ready;
    private bool isFeatherFalling;
    
    public void card_preparation(bool status)
    {
        if (!status)
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
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
            Physics.gravity = new Vector3(0, -reducedGravity, 0);
        }
        
    }   
}
