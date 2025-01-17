using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheLight : MonoBehaviour
{
    public GameObject sprite1; // Main sprite
    public GameObject sprite2; // Alternate sprite

    // Call this method to switch sprites
    public void SwitchToSprite1()
    {
        if (sprite1 != null && sprite2 != null)
        {
            sprite1.SetActive(false);
            sprite2.SetActive(true);
        }
        else
        {
            Debug.LogError("Sprites are not set in the TrafficLight prefab.");
        }
    }
    public void SwitchToSprite2()
    {
        if (sprite1 != null && sprite2 != null)
        {
            sprite1.SetActive(true);
            sprite2.SetActive(false);
        }
        else
        {
            Debug.LogError("Sprites are not set in the TrafficLight prefab.");
        }
    }
}
