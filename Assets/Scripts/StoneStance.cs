using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneStance : MonoBehaviour
{
    public bool stoned = false;
    private FirstPersonController firstPersonController;
    
    void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            stoned = !stoned;
        }
    }
}
