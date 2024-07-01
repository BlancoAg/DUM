using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject target;
    public int switchId; // Identifier for the switch

    public void Execute()
    {
        IActivate currentTarget = target.GetComponent<IActivate>();
        if (currentTarget != null)
        {
            currentTarget.Active(switchId); // Pass switchId to the Active method
        }
    }
}