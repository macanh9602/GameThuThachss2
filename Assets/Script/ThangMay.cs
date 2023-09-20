using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ThangMay : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveX(3f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCubic);

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
