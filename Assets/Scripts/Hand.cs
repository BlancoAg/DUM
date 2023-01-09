using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
public class Hand : MonoBehaviour
{   
    public int counter;
    private int y = 0;
    private int i = 0;
    public GameObject placehold;
    public List<GameObject> Cards = new List<GameObject>();
    //public List<int> test = new List<int>{0,1,2,3,4,5,6,7,8,9,10};
    // Start is called before the first frame update
    void Start()
    {
        Cards.Add(placehold);
        Debug.Log(placehold.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
         {
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hit;
             if (Physics.Raycast(ray, out hit, 2))
             {
                 if (hit.collider != null && hit.collider.tag == "Card")
                 {
                     Cards.Add(hit.collider.gameObject);
                     hit.collider.gameObject.SetActive(false);
                 }
             }
        }

        if(Input.GetAxis("Mouse ScrollWheel")> 0f || Input.GetKeyDown(KeyCode.Q)){
            Debug.Log("Scrol Up");
            y = y+1;    
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown(KeyCode.Q)){
            Debug.Log("Scrol Down");
            y = y -1;            
        }

        if(Cards.Count>0){
            if( y<0 ){
                y = Cards.Count - 1;
            }
            if(y >= Cards.Count){
                y = 0;
            }

            if (Input.GetMouseButtonDown(1)){
                //Cards[y].prepare_card();
                //placehold.prepare_card();
            }
            if (Input.GetMouseButtonDown(1) && Input.GetMouseButtonDown(0)){
                //Cards[y].cast_card();

                //placehold.GetComponent(typeof())();
            }

        }
    
    }
}
    
        


