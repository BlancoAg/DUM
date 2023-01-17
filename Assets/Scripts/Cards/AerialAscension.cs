using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialAscension : MonoBehaviour, ICard
{
    public float levitate = 15.0f;
    public float defaultJumpForce = 5.0f;
    private FirstPersonController firstPersonController;

    private bool ready;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        firstPersonController = player.GetComponent<FirstPersonController>();
    }

    public void card_preparation(bool status)
    {
        Debug.Log("estatus: " + status);
        if (!status)
        {
            Debug.Log("despreparacion");
            firstPersonController.jumpForce = defaultJumpForce;
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
            firstPersonController.jumpForce = levitate;
            //StartCoroutine(ResetJumpForce());
            ready = false;   
        }

        

    }

    //IEnumerator ResetJumpForce()
    //{
    //    yield return new WaitForSeconds(2);
    //    
    //}

}
