using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion.Fluid;
using UnityEngine.SceneManagement;
public class PlayerMainScript : MonoBehaviour
{

    public AudioClip discover_sound;
    public AudioSource saurce;
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
    public string waterTag = "Water";
    public bool swimming = false;

    public GameObject gameOverPanel;
    public GameObject Crosshair;

    public GameObject ScorchShieldIcon;
    public GameObject StoneStanceIcon;
    
    private PlayerMovementTutorial playerMovementTutorial;
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
    }
    void OnCollisionEnter(Collision collision)
{
    // Debug.Log("El tag es " + collision.collider.tag);

    // Verifica si el objeto tiene la etiqueta "brittle_gound" y si las condiciones adicionales son verdaderas
    if (collision.collider.CompareTag("brittle_gound") && !playerMovementTutorial.grounded && stoned)
    {
        // Obtiene el componente Breakable y, si existe, llama al método Break
        Breakable breakableObject = collision.collider.GetComponent<Breakable>();
        if (breakableObject != null) 
        {
            breakableObject.Break();
        }
    }
}
    
    void Update(){  
        if (Input.GetKeyDown("p")){   
        GameObject gameOverPanel = GameObject.Find("gameOverPanel");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverPanel.SetActive(false);
        }
        //if (playerMovementTutorial.grounded && stoned){
        //        falling = false;
        //    }






        if(growing)
        {
            if(gameObject.transform.localScale.x <= bigsize){
                gameObject.transform.localScale =  gameObject.transform.localScale + new Vector3(0.05f, 0.05f, 0.05f);

            }else{
                growing = false;
                big = true;
                Debug.Log("Creciste papi");
                GlobalVariables.character_small = false;
                Debug.Log("Variable Global: " + GlobalVariables.character_small);

            }
        }
        if(shrinking)
        {
            GlobalVariables.character_small = true;
            if(gameObject.transform.localScale.x >= smallsize){
                gameObject.transform.localScale =  gameObject.transform.localScale - new Vector3(0.05f, 0.05f, 0.05f);
            }else{
                shrinking = false;
                big = false;
                Debug.Log("Toy Chiquito");
                
                Debug.Log("Variable Global: " + GlobalVariables.character_small);
            }
        }
    }

    public void ToggleWaterColliders(bool state) {
    GameObject[] waterObjects = GameObject.FindGameObjectsWithTag("Water");

    foreach (GameObject waterObject in waterObjects) {
        BoxCollider boxCollider = waterObject.GetComponent<BoxCollider>();

        if (boxCollider != null) {
            boxCollider.isTrigger = state;
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
            ToggleWaterColliders(false);
        }else if(!can_grow && !shrinking && !growing && !big){
            gameObject.GetComponent<Hand>().play_sound();
            growing = true;
            ToggleWaterColliders(true);
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
            if (swimming)
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
          swimming = true;
       }
   }
   void OnTriggerExit(Collider other)
   {
       if (other.CompareTag("Water"))
       {
           swimming = false;
       }
   }
}