using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialAscension : MonoBehaviour
{
    public float levitate = 15.0f;
    public float defaultJumpForce = 5.0f;
    private FirstPersonController firstPersonController;

    void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            firstPersonController.jumpForce = levitate;
            StartCoroutine(ResetJumpForce());
        }
    }

    IEnumerator ResetJumpForce()
    {
        yield return new WaitForSeconds(2);
        firstPersonController.jumpForce = defaultJumpForce;
    }

}
