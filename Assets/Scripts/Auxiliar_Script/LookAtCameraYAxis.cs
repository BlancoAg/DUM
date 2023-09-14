using UnityEngine;

public class LookAtCameraYAxis : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        // Find the main camera by tag or other means
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            //Debug.LogError("Main camera not found. Make sure your camera is tagged as 'MainCamera' or set the reference manually.");
        }
    }

    private void Update()
    {
        // Check if the camera reference is valid
        if (mainCamera != null)
        {
            // Rotate the object to look at the camera only in the Y-axis
            Vector3 lookAtPosition = mainCamera.transform.position;
            lookAtPosition.y = transform.position.y; // Lock the Y-axis
            transform.LookAt(lookAtPosition);
        }
    }
}

