using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elavator : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 originPos;
    public Vector3 posToGo;
    private void Awake()
    {
        originPos = transform.position;
    }
    public void MoveUp()
    {
        StopAllCoroutines();
        StartCoroutine(MoveToPosition(this.transform, posToGo, 1f));
    }
    public void MoveDown()
    {
        StopAllCoroutines();
        StartCoroutine(MoveToPosition(this.transform, originPos, 1f));
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
