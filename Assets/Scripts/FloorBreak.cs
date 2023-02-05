using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBreak : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {

                if (other.tag == "Player" && other.GetComponent<PlayerMainScript>().falling == true){
                    GetComponent<Rigidbody>().isKinematic = false;
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    Debug.Log(other.name);
    }
}
}
