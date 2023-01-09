using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<GameObject> cardsInHand;
    public int currentCardIndex;

    void Start()
    {
        cardsInHand = new List<GameObject>();
        currentCardIndex = 0;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject objectHit = hit.transform.gameObject;
                if (objectHit.tag == "Card")
                {
                    cardsInHand.Add(objectHit);
                    Debug.Log("Added " + objectHit.name + " to hand.");
                }
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if (currentCardIndex + 1 >= cardsInHand.Count)
            {
                currentCardIndex = 0;
            }
            else
            {
                currentCardIndex++;
            }
            if (cardsInHand.Count > 0)
{
    Debug.Log("Selected " + cardsInHand[currentCardIndex].name);
}

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if (currentCardIndex <= 0)
            {
                currentCardIndex = cardsInHand.Count - 1;
            }
            else
            {
                currentCardIndex--;
            }
            if (cardsInHand.Count > 0)
            {
                Debug.Log("Selected " + cardsInHand[currentCardIndex].name);
            }

        }

        if(Input.GetMouseButtonDown(1))
        {
            // Check if there are any cards in the hand
        if (cardsInHand.Count > 0)
        {
            // Check if the current card has a .prepare_card method
            if (cardsInHand[currentCardIndex].GetComponent<TestCard>() != null)
            {
                // Call the .prepare_card method
                cardsInHand[currentCardIndex].GetComponent<TestCard>().prepare_card();
            }
            if (Input.GetMouseButtonDown(1) && Input.GetMouseButtonDown(0))
            {
            if (cardsInHand[currentCardIndex].GetComponent<TestCard>() != null)
            {
                // Call the .cast_card method
                cardsInHand[currentCardIndex].GetComponent<TestCard>().cast_card();
            }
            }
        }
        }
        
        
    }
}
