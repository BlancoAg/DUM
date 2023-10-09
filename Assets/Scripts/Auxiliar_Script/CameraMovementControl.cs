using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementControl : MonoBehaviour
{

    public bool walking;
    public bool small;
    public bool stoned;

    // Variables para ajustar la velocidad y suavidad de la sacudida
    public float idleSpeed = 0.2f;
    public float normalSpeed = 5.0f;
    public float smallSpeed = 2.0f;
    public float stonedSpeed = 10.0f;
    public float shakeAmount = 0.1f;
    public float shakeDuration = 0.2f;

    private Vector3 originalPosition;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
        currentSpeed = normalSpeed; // Inicialmente, la velocidad es normal
    }

    // Update is called once per frame
    void Update()
    {

    }


}


