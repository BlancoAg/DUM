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
    public float UpperwindForce;
    public float LateralwindForce;
    public float FrontalwindForce;
    //public List<string> direction = ;
    public bool already_afected = false;
    private void Start(){
                
        //eulerAngX = transform.eulerAngles.x;
        //eulerAngY = transform.eulerAngles.y;
        //eulerAngZ = transform.eulerAngles.z;
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
        //if (other.tag == "Player" && other.GetComponent<PlayerMainScript>().stoned == false)
        if (other.tag == "Player" && !other.GetComponent<PlayerMainScript>().stoned)
        {
           if(other.GetComponent<ConstantForce>() && !already_afected){
            already_afected = true;
            other.GetComponent<ConstantForce>().force = other.GetComponent<ConstantForce>().force + new Vector3(LateralwindForce,UpperwindForce,FrontalwindForce);
           }
        }

        if(other.GetComponent<ConstantForce>() && other.tag != "Player"){
            other.GetComponent<ConstantForce>().force = other.GetComponent<ConstantForce>().force + new Vector3(LateralwindForce,UpperwindForce,FrontalwindForce);
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
        if(other.GetComponent<ConstantForce>() && already_afected){
            already_afected = false;
            other.GetComponent<ConstantForce>().force = other.GetComponent<ConstantForce>().force - new Vector3(LateralwindForce,UpperwindForce,FrontalwindForce);
        }
    }
    private void OnTriggerStay(Collider other) {
        if (already_afected && other.GetComponent<PlayerMainScript>().stoned){
            already_afected = false;
            other.GetComponent<ConstantForce>().force = other.GetComponent<ConstantForce>().force - new Vector3(LateralwindForce,UpperwindForce,FrontalwindForce);
        }
        if ( !other.GetComponent<PlayerMainScript>().stoned && !already_afected){
        already_afected = true;
        other.GetComponent<ConstantForce>().force = other.GetComponent<ConstantForce>().force + new Vector3(LateralwindForce,UpperwindForce,FrontalwindForce);
    }
    }
}

