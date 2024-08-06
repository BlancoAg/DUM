using UnityEngine;

public class ColliderActivator : MonoBehaviour
{
    private Collider parentCollider;
    private Collider childCollider;
    private MeshRenderer childMeshRenderer;
    private Material childMaterial;
    public float maxDistance = 5f; // The distance at which the object is fully opaque

    void Start()
    {
        // Get the Collider component attached to the parent GameObject
        parentCollider = GetComponent<Collider>();

        // Ensure the parent collider is a trigger
        parentCollider.isTrigger = true;

        // Find the child GameObject and get its components
        Transform childTransform = transform.GetChild(0); // Assuming the child is the first child
        childCollider = childTransform.GetComponent<Collider>();
        childMeshRenderer = childTransform.GetComponent<MeshRenderer>();

        if (childCollider != null)
        {
            childCollider.enabled = false; // Disable the child Collider at the start
        }

        if (childMeshRenderer != null)
        {
            childMeshRenderer.enabled = false; // Disable the child MeshRenderer at the start
            childMaterial = childMeshRenderer.material;
            SetMaterialOpacity(0f); // Set initial opacity to 0 (fully transparent)
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puppet"))
        {
            // Activate the child Collider and MeshRenderer
            if (childCollider != null)
            {
                childCollider.enabled = true;
            }

            if (childMeshRenderer != null)
            {
                childMeshRenderer.enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Puppet"))
        {
            // Deactivate the child Collider and MeshRenderer
            if (childCollider != null)
            {
                childCollider.enabled = false;
            }

            if (childMeshRenderer != null)
            {
                childMeshRenderer.enabled = false;
                SetMaterialOpacity(0f); // Reset opacity to 0 when puppet leaves
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Puppet"))
        {
            // Calculate the distance between the puppet and the parent object
            float distance = Vector3.Distance(other.transform.position, transform.position);
            // Calculate the opacity based on the distance
            float opacity = Mathf.Clamp01(1f - (distance / maxDistance));
            // Set the material opacity
            SetMaterialOpacity(opacity);
        }
    }

    private void SetMaterialOpacity(float opacity)
    {
        if (childMaterial != null)
        {
            Color color = childMaterial.color;
            color.a = opacity;
            childMaterial.color = color;
        }
    }
}
