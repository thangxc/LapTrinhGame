using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private float bounce = 10f;
    private bool active = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (active)
        {
            if (collision.gameObject.CompareTag("Sheep2") || collision.gameObject.CompareTag("Sheep3"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce / collision.gameObject.GetComponent<Rigidbody2D>().mass, ForceMode2D.Impulse);
            }


            if (collision.gameObject.CompareTag("Sheep1"))
            {
                active = false;
                StartCoroutine(MoveToPosition(this.transform, new Vector3(this.transform.position.x, -5.48f, this.transform.position.z), 0.5f));
            }
        }
    }
    private IEnumerator MoveToPosition(Transform objectToMove, Vector3 target, float time)
    {
        Vector3 startPosition = objectToMove.position;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            objectToMove.position = Vector3.LerpUnclamped(startPosition, target, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToMove.position = target; // Ensure it reaches the exact target
    }
}
