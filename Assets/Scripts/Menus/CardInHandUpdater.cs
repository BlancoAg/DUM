using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInHandUpdater : MonoBehaviour
{
    public Hand handScript;
    public Image cardImage;
    public GameObject cardToCast;
    public TMP_Text cardText;

    void Update()
    {
        if (handScript.cardsInHand.Count > 0)
        {
            cardToCast.SetActive(true);
            GameObject currentCard = handScript.cardsInHand[handScript.currentCardIndex];
            Transform quad = currentCard.transform.GetChild(3);
            Material material = quad.GetComponent<Renderer>().material;
            cardImage.material = material;

            // Retrieve the TextMeshPro component from the 5th child of the current card
            string cardTextMeshPro = currentCard.transform.GetChild(4).GetComponent<TMP_Text>().text;
            // Update the text of the TextMeshPro object
            cardText.text = cardTextMeshPro;
        }
    }
}
