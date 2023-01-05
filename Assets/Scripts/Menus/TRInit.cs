using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TRInit : MonoBehaviour
{
// Start is called before the first frame update
public void StartGame()
{
int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
SceneManager.LoadScene(currentSceneIndex + 1);
}
}
