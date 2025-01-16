using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    // The position around which the hands will rotate
    public Vector3 rotationCenter = Vector3.zero;

    // The axis of rotation (e.g., Vector3.up for Y-axis)
    public Vector3 rotationAxis = Vector3.up;

    // Speed for the minute hand (degrees per second)
    public float minuteSpeed = 6f; // 360 degrees in 60 seconds = 6 degrees per second

    // Speed for the hour hand (1/12th of minute speed)
    public float hourSpeed => minuteSpeed / 12f;

    // References to the objects representing the hands
    public Transform minuteHand;
    public Transform hourHand;

    private bool rotateting = false;
    private int clockDir = 1;

    private void Update()
    {
        if (rotateting)
        {
            if (minuteHand != null)
            {
                RotateAround(minuteHand, rotationCenter, rotationAxis*clockDir, minuteSpeed * Time.deltaTime);
            }

            // Rotate the hour hand
            if (hourHand != null)
            {
                RotateAround(hourHand, rotationCenter, rotationAxis* clockDir, hourSpeed * Time.deltaTime);
            }
        }


    }

    public void StopRotating()
    {
        rotateting = false;
        clockDir = 0;
    }
    public void RotateClockWise()
    {
        print(clockDir);
        rotateting = true;
        clockDir = 1;
    }
    public void RotateCounterClockWise()
    {
        print(clockDir);
        rotateting = true;
        clockDir = -1;
    }

    public void RotateAround(Transform hand, Vector3 center, Vector3 axis, float angle)
    {
        // Calculate the position relative to the center
        Vector3 direction = hand.position - center;

        // Rotate the position around the axis
        Quaternion rotation = Quaternion.AngleAxis(angle, axis);
        direction = rotation * direction;

        // Update the hand's position
        hand.position = center + direction;

        // Optionally rotate the hand itself to face the new direction
        hand.rotation = rotation * hand.rotation;
        
    }

    //ignore object
    //public Collider targetCollider;

    //private void Start()
    //{
    //    // Get the Collider component of the current object
    //    Collider thisCollider = GetComponent<Collider>();

    //    // Ensure both Colliders are set
    //    if (thisCollider != null && targetCollider != null)
    //    {
    //        // Ignore collision between the two objects
    //        Physics.IgnoreCollision(thisCollider, targetCollider);
    //    }
    //    else
    //    {
    //        Debug.LogError("Colliders are not set properly!");
    //    }
    //}
}
