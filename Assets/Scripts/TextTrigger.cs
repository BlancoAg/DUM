using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject textUI;
    public ObjectInteraction objectInteraction;

    void Start()
    {
        objectInteraction = GetComponent<ObjectInteraction>();
    }

    void Update()
    {
        int counter = objectInteraction.counter;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == targetObject && counter == 5)
                {
                    textUI.SetActive(true);
                }
            }
        }
    }
}

