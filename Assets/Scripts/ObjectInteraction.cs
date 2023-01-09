using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public int counter;

    void Update()
    {
         if (Input.GetMouseButtonDown(0))
         {
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hit;
             if (Physics.Raycast(ray, out hit))
             {
                 if (hit.collider != null && hit.collider.tag == "Card")
                 {
                     hit.collider.gameObject.GetComponent<Collider>().enabled = false;
                     hit.collider.gameObject.GetComponent<Renderer>().enabled = false;
                     counter++;
                 }
             }
         }
     }
}
