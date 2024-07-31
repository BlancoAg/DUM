using UnityEngine;
using System.Collections;

public class CameraLookAt : MonoBehaviour
{
    public Transform target_to_look; // Target object to look at
    public float rotationSpeed = 5f; // Speed of rotation towards the target
    private PlayerMovementTutorial playerMovement;

    private Quaternion original_rotation;
    private Coroutine lookCoroutine;

    private void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovementTutorial>();
    }

    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            Debug.Log("Mira para alla wacho");
            start_looking(target_to_look, 3f); // Example: 3 seconds
        }
    }

    public void start_looking(Transform target, float time = 0f)
    {
        original_rotation = transform.rotation;
        target_to_look = target;
        lookCoroutine = StartCoroutine(look_at_target(target, time));
    }

    public void stop_looking()
    {
        if (lookCoroutine != null)
        {
            StopCoroutine(lookCoroutine);
        }
        // transform.rotation = original_rotation;
        Debug.Log("A donde miras wachin?");
        StartCoroutine(look_at_origin());
    }

    IEnumerator look_at_origin()
    {
        Quaternion targetRotation = original_rotation;
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }
        playerMovement.enabled = true;

    }

    IEnumerator look_at_target(Transform target, float time)
    {
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);

        if (time == 0f)
        {
            while (true)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                yield return null;
            }
        }
        else
        {
            float elapsedTime = 0f;
            while (elapsedTime < time)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            stop_looking(); // Automatically stop looking after the specified time
        }
    }
}
