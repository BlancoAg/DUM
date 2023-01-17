using UnityEngine;

public class WindZone : MonoBehaviour
{
public float force = 10.0f;
public GameObject player;

private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.tag == "Player")
    {
        player = other.gameObject;
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        playerRb.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
}