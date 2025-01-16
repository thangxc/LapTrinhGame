using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBoundaryManagement : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManagement.Instance.EndGame();
        Destroy(collision.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManagement.Instance.EndGame();
        Destroy(collision.gameObject);
    }
}
