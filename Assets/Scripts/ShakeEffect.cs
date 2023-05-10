using UnityEngine;
using System.Collections;

public class ShakeEffect : MonoBehaviour {
    
    public float slowSpeed = 1f; // slow shaking speed
    public float fastSpeed = 2f; // fast shaking speed
    public float slowAmount = 0.1f; // slow shaking amount
    public float fastAmount = 0.2f; // fast shaking amount
    public float damping = 1f; // how quickly the shake effect should dampen
    public float vibrationSpeed = 10f; // how quickly the vibration effect should oscillate
    public float vibrationAmount = 0.5f; // how much the vibration effect should move the object
    
    private Vector3 originalPosition; // the gameObject's original position
    private Vector3 lastParentPosition; // the parent's position at the last frame
    private Vector3 parentVelocity; // the current velocity of the parent object
    private Vector3 shakeVelocity; // the current velocity of the shake effect
    private float time = 0f; // used to calculate the shake effect
    private float currentSpeed; // current shaking speed
    private float currentAmount; // current shaking amount
    private bool isVibrating = false; // whether the object is currently vibrating or not
    private Vector3 vibrationDirection = Vector3.up; // the direction of the vibration effect
    
    void Start () {
        originalPosition = transform.localPosition;
        lastParentPosition = transform.parent.position;
        currentSpeed = slowSpeed;
        currentAmount = slowAmount;
    }
    
    void Update () {
        time += Time.deltaTime;
        
        parentVelocity = (transform.parent.position - lastParentPosition) / Time.deltaTime;
        
        // Calculate the speed of the parent object
        float parentSpeed = parentVelocity.magnitude;
        
        // If the parent is moving fast, switch to fast shaking speed and amount
        if (parentSpeed > 0.1f) {
            SwitchToFast();
        }
        // If the parent is not moving or moving slowly, switch to slow shaking speed and amount
        else {
            SwitchToSlow();
        }
        
        Vector3 shakeDelta = Vector3.zero;
        if (isVibrating) {
            // Calculate the vibration effect
            shakeDelta = vibrationDirection * Mathf.Sin(time * vibrationSpeed) * vibrationAmount;
        } else {
            // Calculate the normal shake effect
            shakeDelta = Vector3.up * Mathf.Sin(time * currentSpeed) * currentAmount;
        }
        
        shakeVelocity -= shakeVelocity * damping * Time.deltaTime;
        shakeVelocity += shakeDelta * Time.deltaTime;
        
        transform.localPosition = originalPosition + shakeVelocity;
        lastParentPosition = transform.parent.position;
    }
    
    // Switches to slow shaking speed and amount
    void SwitchToSlow() {
        currentSpeed = slowSpeed;
        currentAmount = slowAmount;
    }
    
    // Switches to fast shaking speed and amount
    void SwitchToFast() {
        currentSpeed = fastSpeed;
        currentAmount = fastAmount;
    }
    
    // Toggles the vibration effect on/off
    public void ToggleVibration() {
        if (isVibrating) {
            isVibrating = false;
            vibrationDirection = Vector3.up;
        } else {
            isVibrating = true;
            vibrationDirection = Random.onUnitSphere;
        }
    }
    
}
