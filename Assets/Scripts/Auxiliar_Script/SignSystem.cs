using UnityEngine;
using UnityEngine.UI;

public class SignSystem : MonoBehaviour
{
    public string signText;  // Texto que se mostrará en el diálogo
    public GameObject dialogueBox;  // Caja de diálogo en la interfaz
    public Text dialogueText;  // Componente de texto dentro de la caja de diálogo
    private bool isLookingAtSign = false;

    // NearView()
    float distance;
    float angleView;
    Vector3 direction;

    void Update()
    {
        if (NearView())
        {
            if (!isLookingAtSign)
            {
                ActivateSign();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                ShowDialogue();
            }
        }
        else if (isLookingAtSign)
        {
            DeactivateSign();
        }
    }

    void ActivateSign()
    {
        isLookingAtSign = true;
        dialogueBox.SetActive(true);
    }

    void DeactivateSign()
    {
        isLookingAtSign = false;
        dialogueBox.SetActive(false);
    }

    void ShowDialogue()
    {
        dialogueText.text = signText;
        // Aquí podrías añadir cualquier lógica adicional, como bloquear controles de movimiento, etc.
    }

    bool NearView()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        return distance < 3f;  // Ajusta la distancia según sea necesario
    }
}
