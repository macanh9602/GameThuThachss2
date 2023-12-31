using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class HookController : MonoBehaviour
{
    [SerializeField] Transform targetA;
    [SerializeField] Transform targetB;
    [SerializeField] float time;
    [SerializeField] Ease ease;
    [SerializeField] GameObject playerTransform;
    //float count = 0;
    public GameObject posPlayer;
    //bool onState = false;
    //public bool IsMoveLeft = true;
    [SerializeField] Vector3[] pos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void action(GameObject go)
    {


        go.transform.position = posPlayer.transform.position;
        go.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //transform.DOMove(IsMoveLeft ? targetA.transform.position : targetB.transform.position, time).SetEase(ease).OnComplete(() => { IsMoveLeft = !IsMoveLeft; });
        //transform.DOLocalPath(IsMoveLeft ? pos : (Vector3[])pos.Reverse(),time).SetEase(ease).OnComplete(() => { IsMoveLeft = !IsMoveLeft; });
        //Vector3[] posReverse = System.Array.Reverse(pos);
        
        transform.DOLocalPath(pos, time).SetEase(ease).OnComplete(() => {
            //IsMoveLeft = !IsMoveLeft;
            System.Array.Reverse(pos); });

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerControll>().dongdoc = this;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerControll>().dongdoc = null;
        }
    }

    //
}
