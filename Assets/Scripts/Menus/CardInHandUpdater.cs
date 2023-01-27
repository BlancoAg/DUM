using UnityEngine;
using UnityEngine.UI;

public class CardInHandUpdater : MonoBehaviour
{
    public Hand handScript;
    public Image cardImage;
    public GameObject cardToCast;

    void Update()
    {
        if (handScript.cardsInHand.Count > 0)
        {
            cardToCast.SetActive(true);
            GameObject currentCard = handScript.cardsInHand[handScript.currentCardIndex];
            Transform quad = currentCard.transform.GetChild(3);
            Material material = quad.GetComponent<Renderer>().material;
            cardImage.material = material;
        }
    }
}
