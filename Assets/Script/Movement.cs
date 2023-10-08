using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    Animator animator;

    [SerializeField] float speed = 70f; // toc chay

    [SerializeField] float jumpSpeed = 5f;

    Vector2 vecGravity;
    [SerializeField] float newtonPower = 0f;

    CircleCollider2D thisCollision;
    BoxCollider2D footCollision;

    bool onState = false;
    public DOPathController dongdoc;
    // Start is called before the first frame update
    void Start()
    {
        vecGravity = new Vector2(0f, -Physics2D.gravity.y);
        Debug.Log(Physics2D.gravity);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        thisCollision = GetComponent<CircleCollider2D>();
        footCollision = GetComponent<BoxCollider2D>();
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        //Debug.Log(xInput);
        Move(xInput);
        FlipFace();

        animator.SetFloat("yVelocity", rb.velocity.y); // hoat canh nhay len xuong theo van toc vua y
        Jump();
        //DongDoc();
    }
    void Move(float _xInput)
    {
        rb.velocity = new Vector2(_xInput * speed, rb.velocity.y);
        bool IsMove = Mathf.Abs(rb.velocity.x) > 0;

        //if (rb.velocity != null)
        //{
        animator.SetBool("IsRunning", IsMove);

        //}

    }
    void FlipFace()
    {
        bool IsMove = rb.velocity.x != 0;
        if (IsMove)
        {
            transform.localScale = new Vector3(-Mathf.Sign(rb.velocity.x), transform.localScale.y);
        }
    }

    void Jump()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && footCollision.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            //Debug.Log("jump");
            //rb.AddForce(new Vector2(0, jumpForce));
            rb.velocity = new Vector2(0f, jumpSpeed);
            animator.SetBool("IsJump", true);

        }

        if (rb.velocity.y < 0)   // luc huong xuong dat
        {
            rb.velocity -= newtonPower * vecGravity * Time.deltaTime;


            //Debug.Log(rb.velocity);
        }
        if (rb.velocity.y <= 0 && thisCollision.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            animator.SetBool("IsJump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MovingObject"))
        // cham dat hoac cham vat the bay
        {

            animator.SetBool("IsJump", false);

        }
        if (collision.tag == "Ground")
        // cham dat hoac cham vat the bay
        {

            animator.SetBool("IsJump", false);

        }
    }
    //hello
    /*  void OnCollisionEnter2D(Collision2D collision)
      {
          if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("MovingObject"))
              // cham dat hoac cham vat the bay
          {

              animator.SetBool("IsJump", false);

          }

      }*/
     
}


