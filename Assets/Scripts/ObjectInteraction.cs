using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour, IDataPersistence
{
    private int cardCount = 0;
    public void LoadData(GameData data)
    {
        this.cardCount = data.cardCount;
    }
    public void SaveData(GameData data)
    {
        data.cardCount = this.cardCount;
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
                     //hit.collider.gameObject.GetComponent<Collider>().enabled = false;
                     //hit.collider.gameObject.GetComponent<Renderer>().enabled = false;
                     cardCount++;
                 }
             }
         }
     }
}
