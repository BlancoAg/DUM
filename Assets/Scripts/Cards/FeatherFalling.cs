using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherFalling : MonoBehaviour
{
    public float reducedGravity = 4.905f;

    private Vector3 currentPosition;
    private Vector3 previousPosition;

    void Update()
    {
        previousPosition = currentPosition;
        currentPosition = transform.position;

        if (currentPosition.y < previousPosition.y && Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            // Y direction is decreasing and Ctrl key is held down
            Physics.gravity = new Vector3(0, -reducedGravity, 0);
        }
        else
        {
            // Y direction is not decreasing or Ctrl key is not held down
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
    }
}

