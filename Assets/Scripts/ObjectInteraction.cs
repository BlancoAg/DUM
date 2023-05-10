using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    // public int cardCount = 0;

    // void Start()
    // {
    //     LoadGame();
    // }
    DialogueSystem dialoguesystem;
    private List<string> dialogues;
    private void Start() {
        dialoguesystem = gameObject.GetComponent<DialogueSystem>();
    }
    
    void Update()
    {
        //Debug.Log("test");
         if (Input.GetMouseButtonDown(0))
         {
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hit;
             if (Physics.Raycast(ray, out hit,2))
             //Debug.Log(hit.collider.tag);
             {
                 if (hit.collider != null && hit.collider.tag == "Activator")
                 {
                    Debug.Log("Test_tag");
                    hit.collider.gameObject.GetComponent<Activator>().Execute();
                 }
             }
         }
         
        if(Input.GetKeyDown("f")){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,2))
                {
                if (hit.collider != null && hit.collider.tag == "NPC" )
                {
                    if (dialoguesystem.endend)
                    {
                    dialogues = hit.collider.gameObject.GetComponent<ExcelReader>().gestor_de_dialogo();    
                    }
                    {
                    if(dialoguesystem.talking){
                       Debug.Log("skip");
                       dialoguesystem.skip();
                    }
                    // else if(dialoguesystem.waiting){
                    //    dialoguesystem.end();             
                    // }
                    else if(dialoguesystem.endend){
                       dialoguesystem.Talk(dialogues);
                       }
                    }
                }
            }
        }
    }
}

    // void SaveGame()
    // {
    //     PlayerPrefs.SetInt("CardCount", cardCount);
    //     PlayerPrefs.Save();
    // }

    // void LoadGame()
    // {
    //     if (PlayerPrefs.HasKey("CardCount"))
    //     {
    //         cardCount = PlayerPrefs.GetInt("CardCount");
    //     }
    // }

    // void OnApplicationQuit()
    // {
    //     SaveGame();
    // }

