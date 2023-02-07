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
    //stone stance variables
    public bool stoned = false;
    public float massChangeSpeed = 0.5f;
    private float originalJumpForce;
    public bool falling;

    public GameObject gameOverPanel;
    public GameObject Crosshair;

    public GameObject ScorchShieldIcon;
    public GameObject StoneStanceIcon;
    
    private PlayerMovementTutorial playerMovementTutorial;
    private WaterMovement waterMovement;
    private ComplexFluidInteractor complexFluidInteractor;

    Rigidbody rb;
    
    

    //Wind variables
    public float windForce = 5.0f;
    public float windDuration = 5.0f;
    public bool isWindBlowing = false;
    

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        playerMovementTutorial = GetComponent<PlayerMovementTutorial>();
        waterMovement = GetComponent<WaterMovement>();
         originalJumpForce = playerMovementTutorial.jumpForce;
        
    }
    void Update()
    {  
        //if(stoned && !playerMovementTutorial.grounded){
        //    Debug.Log("stoned");
        //    gameObject.GetComponent<ConstantForce>().force = new Vector3(0,-50f,0);
        //    if (waterMovement.enabled) {
        //        rb.mass = 25f;   
        //    }
        //}
        //else{
        //    back_to_normal();
        //}
        //Growing or Shrinking check
        if(growing)
        {
            if(gameObject.transform.localScale.x <= bigsize){
                gameObject.transform.localScale =  gameObject.transform.localScale + new Vector3(0.01f, 0.01f, 0.01f);
                Debug.Log("Creciendo");
            }else{
                growing = false;
                big = true;
            }
        }
        if(shrinking)
        {
            if(gameObject.transform.localScale.x >= smallsize){
                gameObject.transform.localScale =  gameObject.transform.localScale - new Vector3(0.01f, 0.01f, 0.01f);
                Debug.Log("Encogiendo");
            }else{
                shrinking = false;
                big = false;
            }
        }
    }

    //Player death method
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
     playerMovementTutorial.enabled = false;
     Cursor.lockState = CursorLockMode.None;
     Cursor.visible = true;
     Crosshair.SetActive(false);
    }

    //Small stance method
    public void change_size()
    {
        if(!shrinking && !growing && big){
            shrinking = true;
        }
        if(!shrinking && !growing && !big){
            growing = true;
        }
    }

    //Scorch Shield method
    public void shield_status(bool status)
    {
         shielded = status;
         ScorchShieldIcon.SetActive(shielded);   
    }
    //Stone Stance method
    public void stone_status(bool status)
{
    stoned = status;
    StoneStanceIcon.SetActive(stoned);
    if (stoned)
    {
        Debug.Log("stoned");
        playerMovementTutorial.jumpForce = 1f;
        if (!playerMovementTutorial.grounded){
            gameObject.GetComponent<ConstantForce>().force = new Vector3(0, -50,0);
            falling = true;
        }
        if (waterMovement.enabled)
        {
            rb.mass = 25f;
        }
    }
    else
    {
        gameObject.GetComponent<ConstantForce>().force = new Vector3(0, 0,0);
        playerMovementTutorial.jumpForce = originalJumpForce;
        StartCoroutine(ChangeMassBackToOne());
    }
}
    public void aerial_ascend(){
        Debug.Log("aerial_ascend");
        gameObject.GetComponent<ConstantForce>().force = gameObject.GetComponent<ConstantForce>().force + new Vector3(0, 50,0);
    }

    public void back_to_normal()
    {
         stoned = false;
         shielded = false;
         StoneStanceIcon.SetActive(stoned);   
         ScorchShieldIcon.SetActive(shielded);
         rb.mass = 1f;
         StartCoroutine(ChangeMassBackToOne());
    }

    private IEnumerator ChangeMassBackToOne()
    {
        while (rb.mass > 1f)
        {
            rb.mass -= massChangeSpeed * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        rb.mass = 1f;
    }

   //Water methods
   void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("Water"))
       {
          waterMovement.enabled = true;
          playerMovementTutorial.enabled = false;
       }
   }
   void OnTriggerExit(Collider other)
   {
       if (other.CompareTag("Water"))
       {
           waterMovement.enabled = false;
           playerMovementTutorial.enabled = true;
       }
   }
}
