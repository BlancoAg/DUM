using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion.Fluid;
public class PlayerMainScript : MonoBehaviour
{
    private bool can_grow;

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
    //public bool falling;
    //feather falling variables
    public bool floating;
    public float slowFallForce = 2.0f;
    public float defaultFallForce = 9.8f;

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

    private float weight;
    

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        playerMovementTutorial = GetComponent<PlayerMovementTutorial>();
        waterMovement = GetComponent<WaterMovement>();    
    }
    
    void Update()
    {  
        //if (playerMovementTutorial.grounded && stoned){
        //        falling = false;
        //    }

        if (!playerMovementTutorial.grounded && stoned){
            ////Debug.Log("Falling");

            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.9f)) {
                ////Debug.Log("algo toque :D");
                Breakable breakableObject = hit.collider.GetComponent<Breakable>();
                if (breakableObject != null) {
                breakableObject.Break();
                }
            }
        }
        //if(stoned && !playerMovementTutorial.grounded){
        //    //Debug.Log("stoned");
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

            }else{
                growing = false;
                big = true;
            }
        }
        if(shrinking)
        {
            if(gameObject.transform.localScale.x >= smallsize){
                gameObject.transform.localScale =  gameObject.transform.localScale - new Vector3(0.01f, 0.01f, 0.01f);
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
        can_grow = Physics.Raycast(transform.position, Vector3.up, bigsize * 0.5f + 0.3f);
        if(!shrinking && !growing && big){
            gameObject.GetComponent<Hand>().play_sound();
            shrinking = true;
        }else if(!can_grow && !shrinking && !growing && !big){
            gameObject.GetComponent<Hand>().play_sound();
            growing = true;
        }else{
            gameObject.GetComponent<Hand>().fail_sound();
        }
    }

    //Scorch Shield method
    public void shield_status(bool status)
    {
         shielded = status;
         ScorchShieldIcon.SetActive(shielded);   
    }
    //Stone Stance method
    public void stone_status(bool status , float weight)
    {
        stoned = status;
        StoneStanceIcon.SetActive(stoned);
        if (stoned)
        {
            gameObject.GetComponent<ConstantForce>().force = gameObject.GetComponent<ConstantForce>().force + new Vector3(0, - weight,0);
            //gameObject.GetComponent<ConstantForce>().force = new Vector3(0, -30,0);
            //playerMovementTutorial.jumpForce = 1f;
            if (waterMovement.enabled)
            {
                rb.mass = 25f;
            }
        }
        else
        {
            gameObject.GetComponent<ConstantForce>().force = gameObject.GetComponent<ConstantForce>().force - new Vector3(0, - weight,0);
            //gameObject.GetComponent<ConstantForce>().force = new Vector3(0, 0,0);
            //playerMovementTutorial.jumpForce = originalJumpForce;
            StartCoroutine(ChangeMassBackToOne());
        }
    }
    
    public void feather_falling(bool status)
    {
        floating = status;
        if (floating)
        {
            rb.drag = slowFallForce;
        }
        else
        {
            rb.drag = defaultFallForce;
        }
            
    }

    // public void aerial_ascend(){
    //     //Debug.Log("aerial_ascend");
    //     gameObject.GetComponent<ConstantForce>().force = gameObject.GetComponent<ConstantForce>().force + new Vector3(0, 50,0);
    // }

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
