using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<GameObject> cardsInHand;
    public int currentCardIndex;
    private Dictionary<string, MonoBehaviour> cardScripts;

    void Start()
    {
        cardsInHand = new List<GameObject>();
        currentCardIndex = 0;

        cardScripts = new Dictionary<string, MonoBehaviour>();
        cardScripts.Add("Card RR", GetComponent<RuneReposition>());
        cardScripts.Add("Card AA", GetComponent<AerialAscension>());
        cardScripts.Add("Card FF", GetComponent<FeatherFalling>());
        // add any other card-script mappings here
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 2))
            {
                GameObject objectHit = hit.transform.gameObject;
                if (objectHit.tag == "Card")
                {
                    cardsInHand.Add(objectHit);
                    hit.collider.gameObject.SetActive(false);
                    string cardName = objectHit.name;
                    if (cardScripts.ContainsKey(cardName))
                    {
                        MonoBehaviour script = cardScripts[cardName];
                        script.enabled = true;
                    }
                    Debug.Log("Added " + objectHit.name + " to deck.");
                }
            }
        }
    }
}
