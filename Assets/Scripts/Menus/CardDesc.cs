using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardDesc : MonoBehaviour
{
    public Hand handScript;
    public Text cardText;
    void Update()
    {
        if (handScript.cardsInHand.Count > 0)
        {
            GameObject currentCard = handScript.cardsInHand[handScript.currentCardIndex];
            Transform canvas = currentCard.transform.GetChild(4);
            Text text = canvas.GetComponentInChildren<Text>();
            cardText.text = text.text;
        }
    }
}
