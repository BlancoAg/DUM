using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public float damageInterval = 2.0f;
    private float elapsedTime = 0.0f;
    //public ScorchShield scorchShield;
    private GameObject player;
    private void OnTriggerStay(Collider other)
    {
        player = GameObject.Find("Player");
        if (other.gameObject.tag == "Player" && gameObject.tag == "Fire")
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= damageInterval)
            {
                PlayerMainScript damageable = other.GetComponent<PlayerMainScript>();
            if (damageable != null && !player.GetComponent<PlayerMainScript>().shielded)
            {
                damageable.Die();
            }
            }
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
              Damageable damageable = other.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.Die();
            }  
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            elapsedTime = 0.0f;
        }
    }
}
