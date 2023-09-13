using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialAscension : MonoBehaviour, ICard
{
    private bool ready;
    //public GameObject AAIcon;
    //public GameObject player;
    
    void Start()
    {

    }

    public void card_preparation(bool status)
    {
        Debug.Log("estatus: " + status);
        if (!status)
        {
            //Debug.Log("despreparacion");
            //firstPersonController.jumpForce = defaultJumpForce;
            ready = false;
            //AAIcon.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerMovementTutorial>().jumpForce = 5;
            return; 
        }
        ready = status;
        Debug.Log("Card "+ gameObject.name +" is ready");
        //AAIcon.SetActive(true);
        
        return; 
    }

    public void cast_card()
    {
        if (ready)
        {
            // reset y velocity
            Rigidbody rb = GameObject.Find("Player").GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(transform.up * 10f, ForceMode.Impulse);
        }
    }

    //IEnumerator ResetJumpForce()
    //{
    //    yield return new WaitForSeconds(2);
    //    
    //}

}
