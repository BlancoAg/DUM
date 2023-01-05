using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherFalling : MonoBehaviour
{
    public float reducedGravity = 4.905f;

void Update()
{
    // Check if Ctrl key is held down
    if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
    {
        // Set gravity to reduced value
        Physics.gravity = new Vector3(0, -reducedGravity, 0);
    }
    else
    {
        // Set gravity to normal value
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }
}



}
