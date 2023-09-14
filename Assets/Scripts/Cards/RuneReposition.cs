using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneReposition : MonoBehaviour, ICard
{
    private Camera mainCamera;
    private bool ready; 

    void Start()
    {
        mainCamera = Camera.main;   
    }

    public void card_preparation(bool status)
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

    public void cast_card()
    {
        var player = GameObject.Find("Player");
        if (ready)
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
            {
                GameObject target = hit.transform.gameObject;
                if (target.CompareTag("Rune"))
                {   
                    ////Debug.Log(target.GetChild(0).name);
                    player.transform.position = target.gameObject.transform.position;
    
                    ready = false;
                }
            }
        }
    }
}
