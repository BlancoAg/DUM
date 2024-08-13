using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LillyPads : MonoBehaviour
{
    void Update()
    {
        Debug.Log("Lilli pad cree" + GlobalVariables.character_small);
        GetComponent<Collider>().enabled = GlobalVariables.character_small;
    }
}
