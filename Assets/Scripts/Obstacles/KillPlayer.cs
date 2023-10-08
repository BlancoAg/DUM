using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public float damageInterval = 2.0f;
    private float elapsedTime = 0.0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Puppet"))
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= damageInterval)
            {
                PlayerMainScript player = other.GetComponent<PlayerMainScript>();
                Damageable damageable = other.GetComponent<Damageable>();

                if (damageable != null)
                {
                    if (!player || !player.shielded)
                    {
                        damageable.Die();
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Puppet"))
        {
            elapsedTime = 0.0f;
        }
    }
}
