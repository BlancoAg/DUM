using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialAscension : MonoBehaviour, ICard
{
    private bool ready;
    public GameObject AAIcon;
//  public GameObject player;

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
            AAIcon.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerMovementTutorial>().jumpForce = 5;
            return; 
        }
        ready = status;
        Debug.Log("Card "+ gameObject.name +" is ready");
        AAIcon.SetActive(true);
        
        return; 
    }

    public void cast_card()
    {
        if (ready)
        {
            // Debug.Log("cast card AA");
            //var player = GameObject.Find("Player").GetComponent<ConstantForce>();
            GameObject.Find("Player").GetComponent<PlayerMovementTutorial>().jumpForce = 20;
            // player.aerial_ascend();
            // StartCoroutine(ResetJumpForce());
            // dddddddddddwready = false;   
        }

        

    }

    //IEnumerator ResetJumpForce()
    //{
    //    yield return new WaitForSeconds(2);
    //    
    //}

}
