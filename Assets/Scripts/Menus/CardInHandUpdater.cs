using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInHandUpdater : MonoBehaviour
{
    public Hand handScript;
    public Image cardImage;
    public GameObject cardinhand;
    public GameObject cardToCast;
    public TMP_Text cardText;

    void Update()
{
    if (handScript.cardsInHand.Count > 0)
    {
        cardinhand.SetActive(true);
        GameObject currentCard = handScript.cardsInHand[handScript.currentCardIndex];
        Transform quad = currentCard.transform.GetChild(3);
        Renderer renderer = quad.GetComponent<Renderer>();

        // Use Renderer.sharedMaterial instead of Renderer.material
        Material material = renderer.sharedMaterial;
        cardImage.material = material;

        // Since cardinhand is a GameObject, you cannot directly set its material.
        // You need to access the renderer component of the cardinhand object.
        Renderer cardinhandRenderer = cardinhand.GetComponent<Renderer>();
        if (cardinhandRenderer != null)
        {
            cardinhandRenderer.sharedMaterial = material;
        }

        // Retrieve the TextMeshPro component from the 5th child of the current card
        string cardTextMeshPro = currentCard.transform.GetChild(4).GetComponent<TMP_Text>().text;

        // Update the text of the TextMeshPro object
        cardText.text = cardTextMeshPro;
    }
}

}
