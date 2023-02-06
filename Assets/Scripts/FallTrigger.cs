using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
     List <GameObject> currentCollisions = new List <GameObject> ();
     
    private void OnCollisionEnter(Collision col) {
         // Add the GameObject collided with to the list.
         currentCollisions.Add (col.gameObject);
 
         // Print the entire list to the console.
         foreach (GameObject gObject in currentCollisions) {
             Debug.Log(gObject.name);
         }
     }
 
     void OnCollisionExit (Collision col) {
 
         // Remove the GameObject collided with from the list.
         currentCollisions.Remove (col.gameObject);
 
         // Print the entire list to the console.
         foreach (GameObject gObject in currentCollisions) {
            Debug.Log(gObject.name);
         }
     }
 }
