using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHandler : MonoBehaviour
{
    private MeshRenderer MeshRenderer;

    private void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
    }
    public float velocity;

    // Update is called once per frame
    void Update()
    {
        MeshRenderer.material.mainTextureOffset += Vector2.right * Time.deltaTime * velocity;
    }
/*    void MoveHorizontal() 
    {
        this.transform.position += Vector3.left * Time.deltaTime * velocity;
    }*/
}
