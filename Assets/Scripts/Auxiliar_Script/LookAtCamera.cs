using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // Find the main camera in the scene
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found in the scene!");
        }
    }

    void Update()
    {
        if (mainCamera != null)
        {
            // Calculate the direction from the object to the camera
            Vector3 lookDir = mainCamera.transform.position - transform.position;

            // Make the object rotate to face the camera
            transform.rotation = Quaternion.LookRotation(lookDir);
        }
    }
}
