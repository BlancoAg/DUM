using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    // Este método cierra el juego
    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // Esto es para detener el juego en el editor de Unity
        #endif
    }

    // Este método carga la escena llamada "DemoHassan"
    public void PlayAgain()
    {
        SceneManager.LoadScene("DemoHassan");
    }
}
