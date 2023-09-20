using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defeat : MonoBehaviour
{
    [SerializeField] private GameObject Panel_loss;
    [SerializeField] private CanVas Oj_canvas;
    private playerControll p;
    private void Start()
    {
        GameObject playerGameObject = GameObject.Find("Player");
        p = playerGameObject.GetComponent<playerControll>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("bottom") ||
            collision.gameObject.CompareTag("stamping")||
             collision.gameObject.CompareTag("gear")
            )
        {
            Panel_loss.SetActive(true);
            Oj_canvas.setTxtLoss();
            p.isDie();
          //  Destroy(gameObject, 2);
        }
    }
}
