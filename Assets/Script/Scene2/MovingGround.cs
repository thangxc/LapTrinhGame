using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        StartCoroutine(BeingPush(collision.gameObject));
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StopAllCoroutines();
    }
    private IEnumerator BeingPush(GameObject sheep)
    {   while (true)
        {
            sheep.GetComponent<Rigidbody2D>().AddForce(30 * Vector3.left, ForceMode2D.Force);
            yield return null;
        }
    }    
}
