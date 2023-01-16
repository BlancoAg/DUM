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
        void Start()
        {
            handScript = GameObject.Find("GameObjectName").GetComponent<Hand>();
            if (handScript == null)
            {
                Debug.LogError("Hand script not found");
            }
        }
    }

    void Update()
    {
        if (handScript.cardsInHand.Count > images.Count)
        {
            GameObject currentCard = handScript.cardsInHand[handScript.cardsInHand.Count - 1];
            Image newImage = Instantiate(imagePrefab, menu);
            newImage.material = currentCard.transform.GetChild(3).GetComponent<Renderer>().material;
            images.Add(newImage);
            grid.enabled = true;
        }
    }
}
