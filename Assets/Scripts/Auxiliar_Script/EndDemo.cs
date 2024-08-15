using UnityEngine;
using System.Collections;  // Necesario para IEnumerator
using UnityEngine.UI;  // Necesario para trabajar con UI
using UnityEngine.SceneManagement;  // Necesario para reiniciar la escena

public class EndDemo : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip triggerSound;
    public Image displayImage;  // La imagen que se mostrará
    public Sprite imageToShow;  // La imagen que deseas mostrar

        // NearView()
    float distance;
    float angleView;
    Vector3 direction;

    public bool Remote = false;

    private bool hasTriggered = false;
        void Update()
    {
        if ( !Remote && Input.GetKeyDown(KeyCode.E) && NearView() )
            SceneManager.LoadScene("Gracias por jugar");
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {

       SceneManager.LoadScene("Gracias por jugar");
        }
    }

    
    bool NearView() // it is true if you near interactive object
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        if (distance < 3f) return true; // angleView < 35f && 
        else return false;
    }
}
