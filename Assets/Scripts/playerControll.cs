using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControll : MonoBehaviour
{
  
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 vecGravity;
    [SerializeField] float speed = 70f; // toc chay
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float newtonPower = 0f;
     private CapsuleCollider2D thisCollision;
    private BoxCollider2D footCollision;

    // Start is called before the first frame update
    void Start()
    {
        vecGravity = new Vector2(0f, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        thisCollision = GetComponent<CapsuleCollider2D>();
        footCollision = GetComponent<BoxCollider2D>();
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xInput = UnityEngine.Input.GetAxisRaw("Horizontal"); // 
        Move(xInput);
        animator.SetFloat("yVelocity", rb.velocity.y); // hoat canh nhay len xuong theo van toc vua y
        Jump();
    }
    void Move(float _xInput)
    {
        if ( footCollision.IsTouchingLayers(LayerMask.GetMask("Ground")) ||  // khi Player dung tren mat dat
            !thisCollision.IsTouchingLayers(LayerMask.GetMask("Ground")) && // khi Player da lo lung trong khong gian
            !footCollision.IsTouchingLayers(LayerMask.GetMask("Ground"))
            )
        {        
                rb.velocity = new Vector2(_xInput * speed, rb.velocity.y);
                bool IsMove = Mathf.Abs(rb.velocity.x) > 0;
                animator.SetBool("isWalk", IsMove);
                FlipFace();     
        }
    }
    void FlipFace()
    {
        bool IsMove = rb.velocity.x != 0;
        if (IsMove)
        {
            transform.localScale = new Vector3(-Mathf.Sign(rb.velocity.x), transform.localScale.y); // thay doi huong di chuyen 
        }
    }

    void Jump()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && footCollision.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed); //  play nhay len cao
            animator.SetBool("isJump", true);
        }
        if (rb.velocity.y < 0)   // luc huong xuong dat
        {
            rb.velocity -= newtonPower * vecGravity * Time.deltaTime;
        }
        if (rb.velocity.y <= 0 && thisCollision.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            animator.SetBool("isJump", false);
        }
    }
    public void isDie()
    {
        animator.SetBool("isDie", true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Ground")
        // cham dat hoac cham vat the bay
        {
            animator.SetBool("isJump", false);

        }
    }

}
