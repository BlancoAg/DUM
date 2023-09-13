using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    DialogueSystem dialoguesystem;
    QuestTrigger questTrigger;
    private List<string> dialogues;

    private void Start()
    {
        dialoguesystem = GetComponent<DialogueSystem>(); // Remove "gameObject."
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 2))
            {
                if (hit.collider != null && hit.collider.CompareTag("Activator"))
                {
                    Debug.Log("Test_tag");
                    hit.collider.gameObject.GetComponent<Activator>().Execute();
                }

                // Check if the hit object has a script component called "QuestTrigger"
                questTrigger = hit.collider.gameObject.GetComponent<QuestTrigger>();
                if (questTrigger != null)
                {
                    // Call the "Trigger" method if it exists
                    questTrigger.Trigger();
                }
            }
        }

        if (Input.GetKeyDown("f"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2))
            {
                if (hit.collider != null && hit.collider.CompareTag("NPC"))
                {
                    Debug.Log("Al menos le pegamos a un NPC");
                    if (dialoguesystem.endend)
                    {
                        dialogues = hit.collider.gameObject.GetComponent<DialogueSystem>().gestor_de_dialogo();
                    }

                    if (dialoguesystem.talking)
                    {
                        Debug.Log("skip");
                        dialoguesystem.skip();
                    }
                    else if (dialoguesystem.endend)
                    {
                        dialoguesystem.Talk(dialogues);
                    }
                }
            }
        }
    }
}
