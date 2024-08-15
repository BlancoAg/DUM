using UnityEngine;

public class SimpleCollisionTest : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision detected with: " + collision.collider.name);
    }
}

