using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Objeto público que se pasará para activar sus componentes
    public GameObject targetObject;
    public GameObject menu;
    public GameObject tutorial;

    public bool testing;

    // Variable pública para el Rigidbody
    public Rigidbody targetRigidbody;

    // Método Play que activará todos los componentes del GameObject
    private void Start() {
        if(testing){
            Play();
        }
    }
    public void Play()
    {
        // Llama al método para activar todos los componentes del GameObject
        menu.SetActive(false);
        SetComponentsActive(targetObject, true);
    }

    public void Tutorial()
    {
        menu.SetActive(false);
        tutorial.SetActive(true);
        // Puedes añadir la lógica para el tutorial aquí
    }

    public void QuitTutorial()
    {
        menu.SetActive(true);
        tutorial.SetActive(false);
        // Puedes añadir la lógica para el tutorial aquí
    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // Esto es para detener el juego en el editor de Unity
        #endif
    }

    // Método para activar/desactivar todos los componentes de un GameObject
    private void SetComponentsActive(GameObject target, bool isActive)
    {
        Component[] components = target.GetComponents<Component>();

        foreach (Component component in components)
        {
            // Ignorar Transform ya que no se puede desactivar
            if (component is Transform)
                continue;

            // Activar o desactivar cada componente dependiendo de su tipo
            if (component is MonoBehaviour)
            {
                ((MonoBehaviour)component).enabled = isActive;
            }
            else if (component is Renderer)
            {
                ((Renderer)component).enabled = isActive;
            }
            else if (component is Collider)
            {
                ((Collider)component).enabled = isActive;
            }
            else if (component is Rigidbody)
            {
                ((Rigidbody)component).isKinematic = !isActive;
            }
            if (targetRigidbody != null)
        {
            targetRigidbody.useGravity = true;
        }
            // Añadir aquí más tipos de componentes si es necesario
        }
    }

    // Activar gravedad en el Rigidbody al iniciar el script
}
