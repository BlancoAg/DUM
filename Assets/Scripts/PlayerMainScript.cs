using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion.Fluid;
public class PlayerMainScript : MonoBehaviour
{
    public float bigsize;
    public float smallsize;
    public bool shielded = false;
    public bool big = true;
    public bool growing;
    public bool shrinking;
    public float maxHealth = 100;
    public float currentHealth;
    public GameObject gameOverPanel;
    public GameObject Crosshair;
    public GameObject ScorchShieldIcon;
    private FirstPersonController firstPersonController;
    private CharacterController characterController;
    private CharacterMovement characterMovement;

    //Wind variables
    public float windForce = 5.0f;
    public float windDuration = 5.0f;
    public bool isWindBlowing = false;
    

    void Start()
    {
        currentHealth = maxHealth;
        firstPersonController = GetComponent<FirstPersonController>();
        characterController = GetComponent<CharacterController>();
        characterMovement = GetComponent<CharacterMovement>();
        
    }
    void Update()
    {  

    if(gameObject.transform.localScale.x <= bigsize){
            Debug.Log("estas grande");
        }else{
            growing = false;
            big = true;
        }

    if(gameObject.transform.localScale.x >= smallsize){
            Debug.Log("toy chiquito");
            }else{
                shrinking = false;
                big = false;
            }
    if(shrinking){gameObject.transform.localScale =  gameObject.transform.localScale - new Vector3(0.01f, 0.01f, 0.01f);}
    if(growing){gameObject.transform.localScale =  gameObject.transform.localScale + new Vector3(0.01f, 0.01f, 0.01f);}
    }
    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
     gameOverPanel.SetActive(true);
     firstPersonController.enabled = false;
     Cursor.lockState = CursorLockMode.None;
     Cursor.visible = true;
     Crosshair.SetActive(false);
    }

    public void change_size()
    {
        if(!shrinking && !growing && big){
            shrinking = true;
        }
        if(!shrinking && !growing && !big){
            growing = true;
        }
    }
    public void shield_status(bool status)
    {
         shielded = status;
         ScorchShieldIcon.SetActive(shielded);   
    }

    public void back_to_normal()
    {
         shielded = false;
         ScorchShieldIcon.SetActive(shielded);
    }

   //Water methods
   void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("Water"))
       {
           characterController.enabled = false;
           firstPersonController.enabled = false;
           GetComponent<CharacterMovement>().enabled = true;
       }
   }
   void OnTriggerExit(Collider other)
   {
       if (other.CompareTag("Water"))
       {
           characterController.enabled = true;
           firstPersonController.enabled = true;
           GetComponent<CharacterMovement>().enabled = false;

       }
   }
}
