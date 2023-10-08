using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CollectUpdate : MonoBehaviour
{
    public Image imagePrefab;
    public List<Image> images = new List<Image>();
    public Hand handScript;
    public RectTransform menu;
    public GridLayoutGroup grid;

    void Start()
    {
        // Your start code here
    }

    void Update()
    {
        if (handScript.cardsInHand.Count > images.Count)
        {
            GameObject currentCard = handScript.cardsInHand[handScript.cardsInHand.Count - 1];
            Image newImage = Instantiate(imagePrefab, menu);

            // Use sharedMaterial instead of material
            newImage.material = currentCard.transform.GetChild(3).GetComponent<Renderer>().sharedMaterial;

            images.Add(newImage);
            grid.enabled = true;
        }
    }
}
