using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGrasp : MonoBehaviour, ICard
{
    public bool ready;

    public string description;

    public string tell_description() {
        return  "test";
    }
    public void card_preparation(bool status, GameObject handGameObject)
    {
        if (!status)
        {
            ready = false;
            return;
        }
        ready = status;
    }

    public void cast_card(GameObject handGameObject)
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // Esto es para detener el juego en el editor de Unity
        #endif
    }
}

