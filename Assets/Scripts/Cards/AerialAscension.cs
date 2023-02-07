using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialAscension : MonoBehaviour, ICard
{
    public float levitate = 15.0f;
    public float defaultJumpForce = 5.0f;
    private FirstPersonController firstPersonController;
    private PlayerMovement player;
    private bool ready;
    public GameObject AAIcon;
//  public GameObject player;

    void Start()
    {
        //player = GameObject.Find("Player");
        //firstPersonController = player.GetComponent<FirstPersonController>();
    }

    public void card_preparation(bool status)
    {
        Debug.Log("estatus: " + status);
        if (!status)
        {
            Debug.Log("despreparacion");
            //firstPersonController.jumpForce = defaultJumpForce;
            ready = false;
            AAIcon.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerMovement>().jumpForce = 5;

            return; 
        }
        ready = status;
        Debug.Log("Card "+ gameObject.name +" is ready");
        AAIcon.SetActive(true);
        GameObject.Find("Player").GetComponent<PlayerMovement>().jumpForce = 20;
        return; 
    }

    public void cast_card()
    {
        if (ready)
        {
            
            //Debug.Log("cast card AA");
            //var  player = GameObject.Find("Player").GetComponent<PlayerMovement>();
            //player.aerial_ascend();
            //StartCoroutine(ResetJumpForce());
            //dddddddddddwready = false;   
            
        }

        

    }

    //IEnumerator ResetJumpForce()
    //{
    //    yield return new WaitForSeconds(2);
    //    
    //}

}
