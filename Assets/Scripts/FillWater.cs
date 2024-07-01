using UnityEngine;

public class FillWater : MonoBehaviour, IActivate
{
    public Transform water;
    public float speed = 1.0f;
    public Vector3 waterPosition;
    public Vector3 filledPosition;
    public Vector3 overfilledPosition;

    public bool filled = false;
    public bool overfilled = false;

    private void Start()
    {
        waterPosition = water.position;
        filledPosition = waterPosition + new Vector3(0, 3, 0);
        overfilledPosition = filledPosition + new Vector3(0, 3, 0); // Adjust the value as needed
    }

    private void Update()
    {
        if (overfilled)
        {
            water.position = Vector3.Lerp(water.position, overfilledPosition, Time.deltaTime * speed);
        }
        else if (filled)
        {
            water.position = Vector3.Lerp(water.position, filledPosition, Time.deltaTime * speed);
        }
        else
        {
            water.position = Vector3.Lerp(water.position, waterPosition, Time.deltaTime * speed);
        }
    }

    public void Active(int switchId)
    {
        if (switchId == 1)
        {
            filled = !filled;
            if (overfilled) overfilled = false; // Reset overfilled if the first switch is toggled
        }
        else if (switchId == 2)
        {
            if (filled)
            {
                overfilled = !overfilled;
            }
        }
    }
}
