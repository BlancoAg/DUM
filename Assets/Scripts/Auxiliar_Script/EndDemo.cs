using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con UI
using UnityEngine.SceneManagement;  // Necesario para reiniciar la escena

public class EndDemo : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip triggerSound;
    public Image displayImage;  // La imagen que se mostrará
    public Sprite imageToShow;  // La imagen que deseas mostrar
    public QuestTrigger Quest;

    float distance;
    float angleView;
    Vector3 direction;

    public bool Remote = false;
    private bool hasTriggered = false;

    void Update()
    {
        if (!Remote && Input.GetKeyDown(KeyCode.E) && NearView() && !hasTriggered)
        {
            Debug.Log("Te toqué");
            
            // Reemplazar el efecto de sonido actual y reproducir el nuevo
            audioSource.clip = triggerSound;
            audioSource.Play();

            // Mostrar la imagen (asegúrate de que `displayImage` y `imageToShow` estén asignados en el Inspector)
            if (displayImage != null && imageToShow != null)
            {
                displayImage.sprite = imageToShow;
                displayImage.enabled = true;  // Mostrar la imagen
            }

            // Marcar que la acción ha sido realizada para evitar repeticiones
            hasTriggered = true;

            // Activar la quest
            if (Quest != null)
            {
                Quest.Trigger();
            }

            // Opcionalmente, puedes cargar una escena después de cierto tiempo
            // SceneManager.LoadScene("Gracias por jugar");
        }
    }

    bool NearView() // Devuelve true si estás cerca del objeto interactivo
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);

        // Verificar si la distancia es menor a 3f
        return distance < 3f; 
    }
}
