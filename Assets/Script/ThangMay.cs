using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ThangMay : MonoBehaviour
{
    [SerializeField] Vector3 end;
    [SerializeField] float timeToMove;
    [SerializeField] LoopType loopType;
    [SerializeField] Ease ease;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(end, timeToMove).SetLoops(-1, loopType).SetEase(ease);

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }

}
