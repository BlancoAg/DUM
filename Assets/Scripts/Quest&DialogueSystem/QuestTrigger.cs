using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public GameObject target;
    public int trigger_id;
    public bool by_proximity = false;
    public bool by_touch = false;
    public bool by_interaction = false;
    public float area_detection;

    // This method is called when another object enters the trigger area.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has a specific tag (you can change "Player" to your desired tag).
        if (other.CompareTag("Player") && by_proximity)
        {
            // Do something when the "Player" enters the trigger area.
            Trigger();
            Debug.Log("Player entered the trigger area.");
        }
    }

    public void Trigger()
    {
        // Assuming "target" has a method called "continue" that takes an int parameter.
        target.GetComponent<DialogueSystem>()._continue(trigger_id);
        Debug.Log("Test");
    }
}
