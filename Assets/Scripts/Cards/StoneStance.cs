using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneStance : MonoBehaviour, ICard
{
    public bool stoned = false;
    private bool ready;
    public GameObject Wind;
    private ParticleSystem WindEffect;
    public GameObject StoneStanceIcon;

    public float weight;

    void Start()
    {
    //WindEffect = Wind.GetComponent<ParticleSystem>();
    //WindEffect.Stop();
    }

    public void card_preparation(bool status, GameObject handGameObject)
    {
        ////Debug.Log("estatus: " + status);
        if (!status)
        {
            ////Debug.Log("despreparacion");
            var player = handGameObject.GetComponent<PlayerMainScript>();
            if(player.stoned){
            player.stone_status(false,weight);
            }
            ready = false;
            //WindEffect.Stop();
            return; 
        }
        ready = status;
        ////Debug.Log("Card "+ gameObject.name +" is ready");
        return; 
    }

    public void cast_card(GameObject handGameObject)
    {      
        if(ready)
        {
           var player = handGameObject.GetComponent<PlayerMainScript>();
           if(ready)
           {
              ////Debug.Log("Card" + gameObject.name + "Played");
              //player.shielded = !player.shielded;
              player.GetComponent<Hand>().PlaySound();
              //WindEffect.Play();
              player.stone_status(true,weight);
              ready = false;
           } 
        }
    }
}