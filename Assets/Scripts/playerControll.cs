using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControll : MonoBehaviour
{
    public musicControll musicControll;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 vecGravity;
    [SerializeField] float speed = 70f; // toc chay
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float newtonPower = 0f;
     private CapsuleCollider2D thisCollision;
    private BoxCollider2D footCollision;

    public bool onState = false;
    public HookController dongdoc;
    Vector3 currentPos;


    [SerializeField] private SpriteRenderer sprite;

    private bool isGround, isWalk;

    // Start is called before the first frame update
    void Start()
    {
        vecGravity = new Vector2(0f, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        thisCollision = GetComponent<CapsuleCollider2D>();
        footCollision = GetComponent<BoxCollider2D>();
        rb.velocity = Vector3.zero;
        currentPos = transform.position;
    }
    public void checkAnimation()
    {
        if (footCollision.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            isGround= true;
        }
        else
        {
            isGround= false;
        }
        animator.SetBool("isWalk", checkMove());
        animator.SetBool("isGround",isGround);
    }
    public bool checkMove()
    {
        if (rb.velocity.x != 0)
        {
             isWalk = true;
            musicControll.runningSound(true);
        }
        else
        {
            isWalk = false;
            musicControll.runningSound(false);
        }
        return isWalk;
    }
    // Update is called once per frame
    void Update()
    {

        //float xInput = UnityEngine.Input.GetAxisRaw("Horizontal"); // 
        //Move(xInput);
        //animator.SetFloat("yVelocity", rb.velocity.y); // hoat canh nhay len xuong theo van toc vua y
        //Jump();
        //DongDoc();

        if (GameManage.instance.isPlay)
        {
            float xInput = UnityEngine.Input.GetAxisRaw("Horizontal"); // 
            checkAnimation();
            Move(xInput);
            animator.SetFloat("yVelocity", rb.velocity.y); // hoat canh nhay len xuong theo van toc vua y
            Jump();
            DongDoc();
        }
        else
        {
            musicControll.runningSound(false);
        }
    }
    public void ResetPlayer()
    {
        transform.position = currentPos;
        animator.SetBool("isDie", false);
       transform.DOScale(new Vector3(1f, 1f, 1f), 1f);

    }
    void Move(float _xInput)
    {
        if ( isGround ||  // khi Player dung tren mat dat
            !thisCollision.IsTouchingLayers(LayerMask.GetMask("Ground")) && // khi Player da lo lung trong khong gian
            !footCollision.IsTouchingLayers(LayerMask.GetMask("Ground"))
            )
        {        
                rb.velocity = new Vector2(_xInput * speed, rb.velocity.y);
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
        }
        if (rb.velocity.y < 0)   // luc huong xuong dat
        {
            rb.velocity -= newtonPower * vecGravity * Time.deltaTime;
        }
    }
    public void isDie()
    {
        animator.SetBool("isDie", true);
        transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Ground")
        // cham dat hoac cham vat the bay
        {
            animator.SetBool("isJump", false);

        }
    }
    ///abc adajfbn
    private void DongDoc()
    {
        //Debug.Log(dongdoc is not null);
        if (UnityEngine.Input.GetKeyDown(KeyCode.X))
        {
            if (!onState && dongdoc is not null)
            {
                gameObject.transform.parent = dongdoc.transform;
                
                //transform.DOMove(target.transform.position, time).SetEase(ease);
                dongdoc.action(gameObject);

            }
            else
            {
                gameObject.transform.parent = null;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;


            }
            onState = !onState;
        }
    }
    
}
