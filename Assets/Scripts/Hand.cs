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
                    hit.collider.gameObject.GetComponent<Collider>().enabled = false;
                    hit.collider.gameObject.GetComponent<Renderer>().enabled = false;
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

        //if(Input.GetMouseButtonDown(1))
        //{
            // Check if there are any cards in the hand
        if (cardsInHand.Count > 0)
        {
            // Check if the current card has a .prepare_card method
        if (cardsInHand[currentCardIndex].GetComponent<TestCard>() != null)
            {
                // Call the .prepare_card method
                //cardsInHand[currentCardIndex].GetComponent<TestCard>().prepare_card();
            
            if (!Input.GetMouseButton(1) && ready){
                ready = false;
                cardsInHand[currentCardIndex].GetComponent<TestCard>().card_preparation(false);
            }

            if (Input.GetMouseButton(1) && !ready){
                ready = true;
                cardsInHand[currentCardIndex].GetComponent<TestCard>().card_preparation(true);
            }
            

            if(Input.GetMouseButtonDown(0) && Input.GetMouseButton(1) && ready)
            {
                // Call the .cast_card method
                cardsInHand[currentCardIndex].GetComponent<TestCard>().cast_card();
            }
        }
    }
    
    }    
        
    
}
