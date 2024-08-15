using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hand : MonoBehaviour
{
    public AudioClip fail_clip;

    public AudioClip pick_up_clip;
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

    public GameObject interfaz;
    private bool ready = true;

    private Animator CardAnimation;
    void Start()
    {
        //cardsInHand = new List<GameObject>();
        //Debug.Log(cardsInHand.Count);
        //currentCardIndex = 0;
        // GlobalVariables.character_talking = true;
        sauce = GetComponent<AudioSource>();

    }

    void Update()
    {   
        if (Input.GetMouseButtonDown(0)){
            // Debug.Log("Boton Derecho");
        }
        try{
        CardAnimation = GameObject.Find("card").GetComponent<Animator>();
        }
        catch{
            // Debug.Log("No tenes cartas papu");
        }
        // if (Input.GetMouseButtonDown(0))
        if (Input.GetKey("e"))
        {
        // Debug.Log("Hiciste");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 3))
            // if (Physics.Raycast(ray, out hit, 2, LayerMask.GetMask("Card")))
            {
                // Debug.Log("le pegaste a algo");
                questTrigger = hit.collider.gameObject.GetComponent<QuestTrigger>();
                if (questTrigger != null)
                {
                    questTrigger.Trigger();
                }
                GameObject objectHit = hit.transform.gameObject;
                if (objectHit.tag == "Card" && GlobalVariables.player_controlling)
                {
                    // Debug.Log("Agarraste una carta");
                    cardsInHand.Add(objectHit);
                    sauce.PlayOneShot(pick_up_clip);
                    hit.collider.gameObject.SetActive(false);
                    // CardShowcase(objectHit);
                    // Debug.Log("Added " + objectHit.tag + " to hand.");
                    // Debug.Log("Added " + objectHit.name + " to hand.");

                }
            }
        }

        if (!ready && Input.GetAxis("Mouse ScrollWheel") > 0f)// forward
        {
            if (cardsInHand.Count > 1){
                CardFlip();
            }
            if (currentCardIndex + 1 >= cardsInHand.Count)
            {
                currentCardIndex = 0;
            }
            else
            {
                currentCardIndex++;
                // CardFlip();
            }
            if (cardsInHand.Count > 0)
            {
                //Debug.Log("Selected " + cardsInHand[currentCardIndex].name);
            }

        }
        else if (!ready && cardsInHand.Count != 0 && Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if (cardsInHand.Count > 1){
                CardFlip();
            }
            if (currentCardIndex <= 0)
            {
                currentCardIndex = cardsInHand.Count - 1;
            }
            else
            {
                currentCardIndex--;
                // CardFlip();
            }
            if (cardsInHand.Count > 0)
            {
                //Debug.Log("Selected " + cardsInHand[currentCardIndex].name);
            }

        }

        if (cardsInHand.Count > 0)
        {
            // if (Input.GetMouseButtonDown(1)){
            //     Debug.Log("Boton Izquierdo");
            // }
            // if (ready){
            //     Debug.Log("B");
            // }
            ICard currentCard = cardsInHand[currentCardIndex].GetComponent<ICard>();
            if (currentCard != null)
            {
                if (!Input.GetMouseButton(1) && ready)
                {
                  //  Debug.Log(ready);
                    un_prepare_card(currentCard);
                }
                if (Input.GetMouseButton(1) && !ready)
                {
                    prepare__card(currentCard);

                
                }
                if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1) && ready)
                {
                //    / Debug.Log("Cast Card in Hand");
                    cast_card(currentCard);
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
        CardAnimation.SetTrigger("swap");
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

    private void cast_card(ICard currentCard){
        CardAnimation.SetTrigger("cast_card");
        CardAnimation.SetBool("prepared",false);
        ready = false;
        currentCard.cast_card(gameObject);
    }
    private void prepare__card(ICard currentCard){
        // CardAnimation.SetTrigger("prepare_card");
        CardAnimation.SetBool("prepared",true);
        ready = true;
        currentCard.card_preparation(true, gameObject);
        PrepSound();
    }
    private void un_prepare_card(ICard currentCard){
        // CardAnimation.SetTrigger("un_prepare_card");
        CardAnimation.SetBool("prepared",false);
        ready = false;
        currentCard.card_preparation(false, gameObject);
    }
    private void CardShowcase(GameObject card){
    GameObject player = GameObject.Find("Player");
    Transform cardToShowTransform = player.transform.Find("Interfaz/CardShowcase/CardToShow");

    if (cardToShowTransform != null)
    {
    GameObject cardToShow = cardToShowTransform.gameObject;

    // Assuming you want to get the material from "QuadFF" and set it to a Renderer component (e.g., MeshRenderer or SpriteRenderer) on the "cardToShow" GameObject
    Image cardRenderer = cardToShow.GetComponent<Image>();

    //GameObject card = GameObject.Find("Card"); // Replace "Card" with the actual name of your card GameObject

    if (cardRenderer != null && card != null)
    {
        Material quadFFMaterial = card.transform.Find("Quad").GetComponent<Renderer>().material;
        cardRenderer.material = quadFFMaterial;
        player.transform.Find("Interfaz/CardShowcase/descripcion_de_carta").GetComponent<TextMeshProUGUI>().text = card.GetComponent<ICard>().tell_description();
    }
    else
    {
        // Debug.LogError("Renderer or Card not found.");
    }
    }
    else
    {
        // Debug.LogError("CardToShow not found.");
    }


    }
}    