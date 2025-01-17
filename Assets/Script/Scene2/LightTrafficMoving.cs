using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrafficMoving : MonoBehaviour
{
    [SerializeField] private GameObject trafficLightPrefab;
    [SerializeField] private Vector3 posToSpawn;
    public void Start()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            GameObject trafficLight = Instantiate(trafficLightPrefab, posToSpawn, Quaternion.identity);
            //boxLight = trafficLight.GetComponent<Collider2D>();
            trafficLight.GetComponent<Rigidbody2D>().velocity = (Vector2.left * 10);
        }
    }    
    
}
