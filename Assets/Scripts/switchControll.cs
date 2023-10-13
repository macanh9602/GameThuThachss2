using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class switchControll : MonoBehaviour
{
    public musicControll musicControll;
    private int flat = 1;
    [SerializeField] private Animator animator_Exit;
    private BoxCollider2D box2D_Exit;
    [SerializeField] private GameObject isActive_Object;
    private GameObject ob_Elevator;
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
        transform.DOMoveY(transform.position.y + 0.3f, 0.5f).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(new Vector3(0,180,18), 0.5f, RotateMode.FastBeyond360).SetLoops(-1);
        transform.DOScale(new Vector3(0.5f,0.5f,0.5f), 0.5f).SetLoops(-1, LoopType.Yoyo);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            if (select_function == 0)
            {
                // Tạo một bản sao của prefab GameObject con
                GameObject childObject = Instantiate(isActive_Object);
                // Gán GameObject cha cho GameObject con
                childObject.transform.parent = GameObject.Find("flyingBoard_layer2").transform;
                // Đặt vị trí và góc quay của GameObject con tương đối với GameObject cha (nếu cần)
                childObject.transform.localPosition = new Vector3(3f, -5f, 0f); // Vị trí tương đối
                childObject.transform.localRotation = Quaternion.identity; // Góc quay tương đối
                gameObject.SetActive(false);
                musicControll.switchSound(true);
            }
            else if (select_function == 1)
            {
                Instantiate(isActive_Object,new Vector3(0,0,0),Quaternion.identity);

                gameObject.SetActive(false);
                musicControll.switchSound(true);
            }
            else if(select_function == 2)
            {
                isActive_Object.SetActive(false);
                gameObject.SetActive(false);
                musicControll.switchSound(true);
            }
            else if(select_function == 3)
            {
                box2D_Exit = isActive_Object.GetComponent<BoxCollider2D>(); // gan component cua Oj_exit cho Box2d
                animator_Exit.SetBool("isExit", true);                // Dieu kien animation  open_exit hoat dong
                Destroy(box2D_Exit);                                   // xoa component dc gan  Oj_exit                      
                Invoke(nameof(ExitClose), 5);              //  sau 5 giay se goi ham ExitClose
                                                           //  Debug.Log("Chức năng đang bảo trì");
                musicControll.switchSound(true);
            }
            else if (select_function == 4)
            {
                ob_Elevator = Instantiate(isActive_Object, new Vector3(7, 1, 0),Quaternion.identity);
                InvokeRepeating(nameof(ActiveElevator), 0, 3);
                gameObject.SetActive(false);
                musicControll.switchSound(true);
            }
        }
    }
    private void ActiveElevator()
    {
        GameObject ob_Elevator = GameObject.Find("Elevator(Clone)");
        if (!ob_Elevator) { CancelInvoke(nameof(ActiveElevator)); flat = 1; }
        else
        {
            ob_Elevator.transform.DOMoveY(ob_Elevator.transform.position.y + (6 * flat), 2)
    .SetEase(Ease.Linear);
            flat *= -1;
        }

    }
    private void ExitClose()
    {
        animator_Exit.SetBool("isExit", false);
        isActive_Object.AddComponent<BoxCollider2D>();

    }
}
