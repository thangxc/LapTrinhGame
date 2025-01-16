using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Vector3 targetPosition; // The target position to move to
    private Vector3 originPosition; // The target position to move to
    public float duration = 2f;      // Duration of the movement in seconds

    private Rigidbody2D rb;
    private Collider2D c2D;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originPosition = transform.position;
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
    public void MoveDoorDown()
    {
        StopAllCoroutines();
        StartCoroutine(MoveToPosition(transform, targetPosition, duration));
        print("Pushing button");
    }
    public void MoveDoorUp()
    {
        StopAllCoroutines();
        StartCoroutine(MoveToPosition(transform, originPosition, duration));
        print("Pushing button");
    }

}
