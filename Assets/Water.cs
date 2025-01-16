using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private float velocity = 0f;
    private float force = 0f;
    // current height
    private float height = 0f;
    //normal height
    private float target_height = 0f;

    public void WaveSpringUpdate(float springStiffness)
    {
        height = transform.localPosition.y;
        // maximum extension
        var x = height - target_height;
        force = springStiffness * x;
        velocity += force;
        var y = transform.localPosition.y;
        transform.localPosition = new Vector3(transform.localPosition.x, y + velocity, transform.localPosition.z);
    }

}
