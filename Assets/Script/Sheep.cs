using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sheep : MonoBehaviour
{

    [HideInInspector]public Rigidbody2D rb;
    private Collider2D Collider2D;
    public int number;
    public int runSpeed;
    public int jumpForce;
    public int mass;

    [HideInInspector]
    public bool isFlagged = false;
    public bool isJumped;

    //SetUp
    public void SetUp() 
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.rb.mass = this.mass;
        this.Collider2D = GetComponent<Collider2D>();
    }
    
    //Moving
    public void Jump()
    {
        //print(isJumped);
        if (rb.velocity.y==0)
        {
            this.rb.AddForce(Vector2.up * this.jumpForce, ForceMode2D.Impulse);
        }
    }
    public void Move(string dir)
    {
        
        StartCoroutine(Moving(dir));
    }
    public void Stop()
    {
        StartCoroutine(Stoping());
    }
    IEnumerator Stoping()
    {

        this.rb.velocity = new Vector2(0, this.rb.velocity.y);

        yield return null;
    }
    IEnumerator Moving(string dir)
    {
        Vector2 vectorDir = Vector2.zero;
        if (dir == "right")
        {
            vectorDir = Vector2.right;
        }
        if (dir == "left")
        {
            vectorDir = Vector2.left;
        }
        this.rb.velocity = new Vector2(vectorDir.x * this.runSpeed, this.rb.velocity.y);
        //rb.AddForce(vectorDir * runSpeed, ForceMode2D.Force);
        yield return null;
    }
    //Check collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.isJumped = false;
        }
        if (collision.gameObject.CompareTag("TrafficLight")&&number==0)
        {
            StartCoroutine(Stoping());
            //print("a");
            //collision.Animator:V
            collision.gameObject.GetComponentsInChildren<Collider2D>()[1].enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Flag")
        {
            isFlagged = true;
            print(this.name+"Enter");
            SheepHandler.Instance.NumberSheepFlagged += 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.isJumped = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Flag")
        {
            isFlagged = false;
            SheepHandler.Instance.NumberSheepFlagged -= 1;
        }
    }

    //

}