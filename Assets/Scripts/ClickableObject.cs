using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    // This method will be called when the GameObject is clicked
    public void OnClick()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse clicks
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits this GameObject
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Call the OnClick method when clicked
                OnClick();
            }
        }
    }
}
