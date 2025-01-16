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

    //Swmiming setup
    private Vector2 movementDirection;
    [SerializeField]
    private float swimmingForceAmount;
    private bool isMoving = false;
    private bool isSwimming = false;

    public Collider2D targetCollider;

    private void Start()
    {
        if (number == 0)
        {
            try
            {
                targetCollider = FindAnyObjectByType<WaterShapeController>().GetComponent<Collider2D>();
                // Get the Collider component of the current object
                Collider2D thisCollider = GetComponent<Collider2D>();

                // Ensure both Colliders are set
                if (thisCollider != null && targetCollider != null)
                {
                    // Ignore collision between the two objects
                    Physics2D.IgnoreCollision(thisCollider, targetCollider);
                }
                else
                {
                    Debug.LogError("Colliders are not set properly!");
                }
            }
            catch
            {
                //Debug.LogError("Colliders are not set properly!");
            }
        }
    }

    private void Update()
    {
        isJumped = !IsGrounded();
        //print(IsGrounded());
    }

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
        if (!isSwimming)
        {
            //print(isJumped);
            //if (!isJumped)
            if(rb.velocity.y==0)
            {
                isJumped = true;
                this.rb.AddForce(Vector2.up * this.jumpForce, ForceMode2D.Impulse);
            }
        }
    }
    public void Move(string dir)
    {
        if (!isSwimming)
        {

            StartCoroutine(Moving(dir));
        }
    }
    //
    public void Stop()
        {
            StartCoroutine(Stoping());
        }
    public void Swimming()
    {
        if (isSwimming)
        {
            //print("a");


            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    movementDirection = new Vector2(0f, 1f);
            //    isMoving = true;
            //}
            //if (Input.GetKeyUp(KeyCode.Space))
            //{
            //    movementDirection = new Vector2(0, -1);
            //}
            movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                //print(movementDirection);
                //print("A");
                isMoving = true;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                //movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                isMoving = false;
            }
            if (isMoving)
            {
                rb.velocity = movementDirection * swimmingForceAmount;
            }
        }
    }

    //
    
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
    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.01f, LayerMask.GetMask("Ground"));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            
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
        if (collision.tag == "Water")
        {
            //print("InWater");
            isSwimming = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //this.isJumped = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Flag")
        {
            isFlagged = false;
            SheepHandler.Instance.NumberSheepFlagged -= 1;
        }
        if (collision.tag == "Water")
        {
            isSwimming = false;
        }
    }

    //

}