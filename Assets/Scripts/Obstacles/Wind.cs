using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    //public float windForce = 5.0f;
    //public float smoothness = 0.1f;
    //private StoneStance stoneSt;
    //public GameObject stoneCard;
    private PlayerMainScript player;

    private float eulerAngX;
    private float eulerAngZ;
    private float eulerAngY;
    //public List<string> direction = ;
    private void Start(){
                
        eulerAngX = transform.eulerAngles.x;
        eulerAngY = transform.eulerAngles.y;
        eulerAngZ = transform.eulerAngles.z;
        player = GetComponent<PlayerMainScript>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // //stoneSt = stoneCard.GetComponent<StoneStance>();
        // Player = GetComponent<PlayerMainScript>();
        // if (!Player.stoned && other.CompareTag("Player"))
        // {
        //     CharacterController characterController = other.GetComponent<CharacterController>();
        //     Vector3 windDirection = new Vector3(-1, 0, 0);
        //     Vector3 windVelocity = windDirection * windForce;
        //     characterController.Move(windVelocity * smoothness);
        // }
        if (other.tag == "Player" && other.GetComponent<PlayerMainScript>().stoned == false)
        {
           if(other.GetComponent<ConstantForce>()){
           other.GetComponent<ConstantForce>().force = other.GetComponent<ConstantForce>().force + new Vector3(0,25,0);
           }
        }
        else if(other.GetComponent<ConstantForce>() && !other.gameObject.CompareTag("Player")){
        other.GetComponent<ConstantForce>().force = other.GetComponent<ConstantForce>().force + new Vector3(0,25,0);
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        // //stoneSt = stoneCard.GetComponent<StoneStance>();
        // Player = GetComponent<PlayerMainScript>();
        // if (!Player.stoned && other.CompareTag("Player"))
        // {
        //     CharacterController characterController = other.GetComponent<CharacterController>();
        //     Vector3 windDirection = new Vector3(-1, 0, 0);
        //     Vector3 windVelocity = windDirection * windForce;
        //     characterController.Move(windVelocity * smoothness);
        // }
        if(other.GetComponent<ConstantForce>()){
            other.GetComponent<ConstantForce>().force = other.GetComponent<ConstantForce>().force - new Vector3(0,25,0);
        }
    }
}

