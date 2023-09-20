using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class switchControll : MonoBehaviour
{
    private int flat = 1;
    private bool isElevator;
    [SerializeField] private Animator animator_Exit;
    private BoxCollider2D box2D_Exit;
    [SerializeField] private GameObject isActive_Object;
    [Header("select_function \n" +
        "0 object FlyingBorad \n" +
        "1 object Bridge \n" +
        "2 object Gear_2 \n" +
        "3 object Exit \n" +
        "4 object Elevator")]
    //[Range(0,3)]
    [SerializeField] private int select_function;
    private void Start()
    {
        flat = 1;
        isElevator = true;
        transform.DOMoveY(transform.position.y + 0.3f, 0.5f).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(new Vector3(0,180,0), 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            if (select_function == 0)
            {
                isActive_Object.SetActive(true);
                gameObject.SetActive(false);

            }
            else if (select_function == 1)
            {
                isActive_Object.SetActive(true);
                gameObject.SetActive(false);
            }
            else if(select_function == 2)
            {
                isActive_Object.SetActive(false);
                gameObject.SetActive(false);
            }
            else if(select_function == 3)
            {
                box2D_Exit = isActive_Object.GetComponent<BoxCollider2D>(); // gan component cua Oj_exit cho Box2d
                animator_Exit.SetBool("isExit", true);                // Dieu kien animation  open_exit hoat dong
                Destroy(box2D_Exit);                                   // xoa component dc gan  Oj_exit                      
                Invoke(nameof(ExitClose), 5);              //  sau 5 giay se goi ham ExitClose                Debug.Log("Chức năng đang bảo trì");
            }
            else if (select_function == 4)
            {
                if(isElevator)
                InvokeRepeating(nameof(ActiveElevator), 0, 3);
                isElevator = false;
                gameObject.SetActive(false);
            }
        }
    }
    private void ActiveElevator()
    {
        isActive_Object.transform.DOMoveY(isActive_Object.transform.position.y + (6*flat), 2).SetEase(Ease.Linear);
        flat *= -1;
    }
    private void ExitClose()
    {
        animator_Exit.SetBool("isExit", false);
        isActive_Object.AddComponent<BoxCollider2D>();

    }
}
