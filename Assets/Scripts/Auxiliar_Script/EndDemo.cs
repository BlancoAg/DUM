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

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {

       SceneManager.LoadScene("Gracias por jugar");
        }
    }
}
