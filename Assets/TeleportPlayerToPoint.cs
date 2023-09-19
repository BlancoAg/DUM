using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerToPoint : MonoBehaviour
{
public GameObject Point;
 private void OnTriggerEnter(Collider other) {
Debug.Log("toque algo");
    if(other.tag == "Player"){
        Debug.Log("es un player :D");
        other.transform.position = Point.transform.position;
    }
}
}


