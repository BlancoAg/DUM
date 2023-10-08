using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialAscension : MonoBehaviour, ICard
{
    private bool ready;

    public GameObject Wind;

    private ParticleSystem WindEffect;
    private PlayerMovementTutorial Player;
    void Start()
    {
    WindEffect = Wind.transform.Find("Wind").GetComponent<ParticleSystem>();
    WindEffect.Stop();
    }

    public void card_preparation(bool status, GameObject handGameObject)
    {
        Debug.Log(WindEffect);
        if(status){
            WindEffect.Play();
        }else{
            WindEffect.Stop();
        }
        //Debug.Log("estatus: " + status);
        if (!status)
        {

            ////Debug.Log("despreparacion");
            //firstPersonController.jumpForce = defaultJumpForce;
            ready = false;
            //AAIcon.SetActive(false);
            var player = handGameObject.GetComponent<PlayerMovementTutorial>().jumpForce = 5;
            return; 
        }
        ready = status;
        //Debug.Log("Card "+ gameObject.name +" is ready");
        //AAIcon.SetActive(true);
        
        return; 
    }

    public void cast_card(GameObject handGameObject)
    {
        if (ready)
        {
            var player = handGameObject.GetComponent<PlayerMainScript>();
            // reset y velocity
            if(Player.readyToDoubleJump){
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(transform.up * 10f, ForceMode.Impulse);
            Player.readyToDoubleJump = false;
            Player.GetComponent<Hand>().AerialSound();

            ready = false;
            }
        }
    }

    IEnumerator trun()
    {

        yield return new WaitForSeconds(2);
        
    }

}
