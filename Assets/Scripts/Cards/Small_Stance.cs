using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Small_Stance : MonoBehaviour
{   
    bool big = true;
    bool biggering = false;
    bool shrinking = false;

    public float smallsize;
    public float bigsize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") && big && (!biggering) && (!shrinking)){            
            shrinking = true;
            return;
        }

        else if(Input.GetKeyDown("e") && (!big) && (!biggering) && (!shrinking)){
            biggering = true;
            //Debug.Log("test");
            //gameObject.transform.position = gameObject.transform.position + new Vector3(0,1,0);
            //gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //big = true;
        }
        if(biggering){
            if(gameObject.transform.localScale.x <= bigsize){
                gameObject.transform.localScale =  gameObject.transform.localScale + new Vector3(0.01f, 0.01f, 0.01f);
            }else{
                biggering = false;
                big = true;
            }
        }
        if(shrinking){
            if(gameObject.transform.localScale.x >= smallsize){
                gameObject.transform.localScale =  gameObject.transform.localScale - new Vector3(0.01f, 0.01f, 0.01f);
            }else{
                shrinking = false;
                big = false;
            }
        }

    }
}
