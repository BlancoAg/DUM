using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    // Variable to track the current state of the object
    private bool isRed = false;

    // Reference to the object's material
    private Material objectMaterial;

    // This method will be called when the GameObject is clicked
    public void OnClick()
    {
        // Toggle the color between red and cyan
        if (isRed)
        {
            objectMaterial.color = Color.cyan;
        }
        else
        {
            objectMaterial.color = Color.red;
        }

        // Update the state
        isRed = !isRed;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the object's material
        objectMaterial = GetComponent<Renderer>().material;
        
        // Set initial color to cyan
        objectMaterial.color = Color.cyan;
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
