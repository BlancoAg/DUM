using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Small_Stance : MonoBehaviour, ICard
{   
    public bool ready;
    //public bool player.big = true;
    //public bool player.biggering = false;
    //public bool player.shrinking = false;
    public GameObject Player;
    public PlayerMainScript player;
    public float smallsize;
    public float bigsize;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Debug.Log(Player.name);
        player = Player.GetComponent<PlayerMainScript>();
    }
    public void card_preparation(bool status){
        Debug.Log("estatus: " + status);
        if (!status)
        {
            Debug.Log("despreparacion");
            ready = false;
            return; 
        }
        ready = status;
        Debug.Log("Card "+ gameObject.name +" is ready");
        return; 
    }

    public void cast_card()
    {
        if(ready){
        Debug.Log("cast_card");
        if(player.big && (!player.biggering) && (!player.shrinking)){            
            player.shrinking = true;
        }

        else if((!player.big) && (!player.biggering) && (!player.shrinking)){
            player.biggering = true;
            //Debug.Log("test");
            //player.transform.position = player.transform.position + new Vector3(0,1,0);
            //player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //player.big = true;
        }
        ready = false;
        }
    }
    // Update is called once per frame
    void Update()
    {   
        Debug.Log(player.biggering);
        Debug.Log(player.shrinking);
        Debug.Log(player.big);
        if(player.biggering){
            if(Player.transform.localScale.x <= bigsize){
                Player.transform.localScale =  player.transform.localScale + new Vector3(0.01f, 0.01f, 0.01f);
            }else{
                player.biggering = false;
                player.big = true;
            }
        }
        if(player.shrinking){
            if(Player.transform.localScale.x >= smallsize){
                Player.transform.localScale =  player.transform.localScale - new Vector3(0.01f, 0.01f, 0.01f);
            }else{
                player.shrinking = false;
                player.big = false;
            }
        }

    }
}
