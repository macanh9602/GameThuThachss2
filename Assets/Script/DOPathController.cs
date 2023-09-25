using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DOPathController : MonoBehaviour
{
    [SerializeField] Transform targetA;
    [SerializeField] Transform targetB;
    [SerializeField] float time;
    [SerializeField] Ease ease;
    [SerializeField] GameObject playerTransform;
    float count = 0;
    public GameObject posPlayer;
    //bool onState = false;
    public bool IsMoveLeft = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    if (!onState)
        //    {
        //        playerTransform.transform.parent = transform;
        //        playerTransform.transform.position = transform.Find("PosPlayer").transform.position;
        //        playerTransform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //        transform.DOMove(target.transform.position, time).SetEase(ease);
        //        count = 1;               
        //    }    
        //    else
        //    {
        //        playerTransform.transform.parent = null;
        //        playerTransform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;             
        //    }
        //    onState = !onState; 
        //}
        

    }
    public void action(GameObject go)
    {
       
       
            go.transform.position = posPlayer.transform.position;
            go.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        transform.DOMove(IsMoveLeft ? targetA.transform.position : targetB.transform.position, time).SetEase(ease).OnComplete(() => { IsMoveLeft = !IsMoveLeft; }) ;
     
       
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


}
