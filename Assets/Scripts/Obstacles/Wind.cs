using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float windForce = 5.0f;
    public float smoothness = 0.1f;
    private StoneStance stoneSt;
    public GameObject stoneCard;
    
    private void OnTriggerStay(Collider other)
    {
        stoneSt = stoneCard.GetComponent<StoneStance>();

        if (!stoneSt.stoned && other.CompareTag("Player"))
        {
            CharacterController characterController = other.GetComponent<CharacterController>();
            Vector3 windDirection = new Vector3(-1, 0, 0);
            Vector3 windVelocity = windDirection * windForce;
            characterController.Move(windVelocity * smoothness);
        }
    }
}
