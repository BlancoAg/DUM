using UnityEngine;
using System.Collections;
public class PlaySoundAndDestroy : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip triggerSound;

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;  // Evita que el sonido se reproduzca varias veces
            audioSource.PlayOneShot(triggerSound);
            StartCoroutine(DestroyAfterSound());
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        // Espera hasta que el sonido haya terminado de reproducirse
        yield return new WaitForSeconds(triggerSound.length);
        
        // Destruye el GameObject
        Destroy(gameObject);
    }
}
