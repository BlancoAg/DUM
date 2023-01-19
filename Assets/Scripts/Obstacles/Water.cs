using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float upForce = 3.0f;
    private CharacterController characterController;

    public GameObject player;
    public GameObject childObject;

    public GameObject stoneCard;
    private StoneStance stoneSt;

    void Start()
    {
        //firstPersonController = player.GetComponent<FirstPersonController>();
        player = GameObject.Find("Player");
        characterController = player.GetComponent<CharacterController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {    
            player = GameObject.Find("Player");
            stoneSt = stoneCard.GetComponent<StoneStance>();
            if (!stoneSt.stoned)
            {
                characterController.Move(Vector3.up * upForce);
            }
            Debug.Log("wet");
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        childObject.SetActive(true);
    //    }
    //}
}
