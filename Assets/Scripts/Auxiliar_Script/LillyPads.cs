using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LillyPads : MonoBehaviour
{
    void Update()
    {
        GetComponent<Collider>().enabled = GlobalVariables.character_small;
    }
}
