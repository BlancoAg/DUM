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
        //Debug.Log("test");
         if (Input.GetMouseButtonDown(0))
         {
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hit;
             if (Physics.Raycast(ray, out hit,2))
             Debug.Log("Test");
             //Debug.Log(hit.collider.tag);
             {
                 if (hit.collider != null && hit.collider.tag == "Activator")
                 {
                    Debug.Log("Test_tag");
                    hit.collider.gameObject.GetComponent<Activator>().Execute();
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
