using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public AudioClip fail_clip;
    public AudioSource sourceCC;
    public AudioClip clip;
    public AudioSource sauce;

    public AudioClip clop;
    public AudioClip prep;
    public AudioClip flip;
    public AudioClip rune;
    public AudioClip aerial;

    QuestTrigger questTrigger;
    public List<GameObject> cardsInHand;
    public int currentCardIndex;

    public GameObject collection;
    public GameObject cardDesc;
    private bool ready = true;
    void Start()
    {
        cardsInHand = new List<GameObject>();
        //Debug.Log(cardsInHand.Count);
        currentCardIndex = 0;
        sauce = GetComponent<AudioSource>();

    }

    void Update()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit,2))
            {
                questTrigger = hit.collider.gameObject.GetComponent<QuestTrigger>();
                if (questTrigger != null)
                {
                    // Call the "Trigger" method if it exists
                    questTrigger.Trigger();
                }
                GameObject objectHit = hit.transform.gameObject;
                if (objectHit.tag == "Card")
                {
                    cardsInHand.Add(objectHit);
                    hit.collider.gameObject.SetActive(false);
                    //Debug.Log("Added " + objectHit.name + " to hand.");
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
                CardFlip();
            }
            if (cardsInHand.Count > 0)
            {
                //Debug.Log("Selected " + cardsInHand[currentCardIndex].name);
            }

        }
        else if (cardsInHand.Count != 0 && Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown("q")) // backwards
        {
            if (currentCardIndex <= 0)
            {
                currentCardIndex = cardsInHand.Count - 1;
            }
            else
            {
                currentCardIndex--;
                CardFlip();
            }
            if (cardsInHand.Count > 0)
            {
                //Debug.Log("Selected " + cardsInHand[currentCardIndex].name);
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
                    PrepSound();
                
                }
                if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1) && ready)
                {
                    currentCard.cast_card(gameObject);

                }
            }
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            collection.SetActive(true);
        }
        else
        {
            collection.SetActive(false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            cardDesc.SetActive(true);
        }
        else
        {
            cardDesc.SetActive(false);
        }
        }
    public void play_sound(){
        sourceCC.PlayOneShot(clip);
    }
    public void fail_sound(){
        sourceCC.PlayOneShot(fail_clip);
    }

    public void PlaySound() {
    sauce.PlayOneShot(clop);
    }
    public void PrepSound()
    {
        sauce.PlayOneShot(prep);
    }
    public void CardFlip()
    {
        sauce.PlayOneShot(flip);
    }
    public void RuneSound()
    {
        sauce.PlayOneShot(rune);
    }
    public void AerialSound()
    {
        sauce.PlayOneShot(aerial);
    }

}    