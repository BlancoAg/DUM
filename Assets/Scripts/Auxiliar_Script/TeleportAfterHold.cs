using UnityEngine;

public class TeleportAfterHold : MonoBehaviour
{
    public GameObject teleportTarget; // El GameObject que define la ubicación de teletransporte
    public AudioClip teleportSound; // El sonido que se reproducirá después de teletransportar
    public AudioSource audioSource; // El componente de AudioSource para reproducir el sonido

    public GameObject Camera;

    private bool isHolding = false;
    private float holdTime = 0f;
    public float requiredHoldTime = 3f; // Tiempo necesario para mantener presionado el botón

    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            if (!isHolding)
            {
                isHolding = true;
                holdTime = 0f;
            }

            holdTime += Time.deltaTime;

            if (holdTime >= requiredHoldTime)
            {
                TeleportPlayer();
                isHolding = false; // Resetea el estado después de teletransportar
            }
        }
        else if (Input.GetKeyUp(KeyCode.B))
        {
            isHolding = false;
        }
         if (Input.GetKey(KeyCode.Z)){
            Camera.SetActive(false);
            Camera.SetActive(true);
         }
    }

    void TeleportPlayer()
    {
        // Teletransporta al jugador a la ubicación del teleportTarget
        transform.position = teleportTarget.transform.position;

        // Reproduce el sonido de teletransporte
        if (audioSource != null && teleportSound != null)
        {
            audioSource.PlayOneShot(teleportSound);
        }
    }
}

