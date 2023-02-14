using UnityEngine;

public class SlideDoorGTP : MonoBehaviour, IActivate
{
    public Transform door;
    public float speed = 5.0f;
    public Vector3 closedPosition;
    public Vector3 openPosition;

    private bool doorIsOpen = false;

    private void Start()
    {
        closedPosition = door.position;
        openPosition = closedPosition + new Vector3(0,-6,0);
    }

    private void Update()
    {
        if (doorIsOpen)
        {
            door.position = Vector3.Lerp(door.position, openPosition, Time.deltaTime * speed);
        }
        else
        {
            door.position = Vector3.Lerp(door.position, closedPosition, Time.deltaTime * speed);
        }
    }


        
    public void Active()
    {
        doorIsOpen = !doorIsOpen;

    }
}
