using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private bool triggerOnce;
    [SerializeField] private UnityEvent WhenEnter;
    [SerializeField] private UnityEvent WhenExit;

    private string nameCollison;
    public TheLight theLight;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (nameCollison == null)
        {
            if (collision.CompareTag("Sheep1")|| collision.CompareTag("Sheep2")|| collision.CompareTag("Sheep3"))
            {
                WhenEnter.Invoke();
                nameCollison = collision.transform.tag;
                theLight.SwitchToSprite1();
            }
            if (collision.CompareTag("Box"))
            {
                WhenEnter.Invoke();
                nameCollison = "Box";
                theLight.SwitchToSprite1();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggerOnce)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            triggerOnce = false;
            return;
        }
        if (!triggerOnce)
        {
            if (collision.CompareTag(nameCollison))
            {
                WhenExit.Invoke();
                nameCollison = null;
                theLight.SwitchToSprite2();
            }
        }
    }
}
