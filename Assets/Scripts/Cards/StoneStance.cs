using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneStance : MonoBehaviour
{
    public bool stoned = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            stoned = !stoned;
        }
    }
}