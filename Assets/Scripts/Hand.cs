using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<GameObject> cardsInHand;
    public int currentCardIndex;
    private bool ready = true;

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

            if (Physics.Raycast(ray, out hit,2))
            {
                GameObject objectHit = hit.transform.gameObject;
                if (objectHit.tag == "Card")
                {
                    cardsInHand.Add(objectHit);
                    hit.collider.gameObject.SetActive(false);
                    Debug.Log("Added " + objectHit.name + " to hand.");
                }
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown("e")) // forward
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
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown("q") ) // backwards
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

        if (cardsInHand.Count > 0)
        {
            ICard currentCard = cardsInHand[currentCardIndex].GetComponent<ICard>();
            if (currentCard != null)
            {
                if (!Input.GetMouseButton(1) && ready)
                {
                    ready = false;
                    currentCard.card_preparation(false);
                }
                if (Input.GetMouseButton(1) && !ready)
                {
                    ready = true;
                    currentCard.card_preparation(true);
                
                }
                if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1) && ready)
                {
                    currentCard.cast_card();
                }
            }
        }
    }
}    