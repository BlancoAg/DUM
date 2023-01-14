using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public int cardCount = 0;

    void Start()
    {
        LoadGame();
    }

    void Update()
    {
         if (Input.GetMouseButtonDown(0))
         {
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hit;
             if (Physics.Raycast(ray, out hit,2))
             {
                 if (hit.collider != null && hit.collider.tag == "Card")
                 {
                     hit.collider.gameObject.GetComponent<Collider>().enabled = false;
                     hit.collider.gameObject.GetComponent<Renderer>().enabled = false;
                     cardCount++;
                 }
             }
         }
     }

    void SaveGame()
    {
        PlayerPrefs.SetInt("CardCount", cardCount);
        PlayerPrefs.Save();
    }

    void LoadGame()
    {
        if (PlayerPrefs.HasKey("CardCount"))
        {
            cardCount = PlayerPrefs.GetInt("CardCount");
        }
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }
}
