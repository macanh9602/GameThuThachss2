﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class defeat : MonoBehaviour
{
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
            if(GameManage.instance.isPlay)
            {
                p.isDie();
                GameManage.instance.end_game();
                Invoke(nameof(GetPanelLoss), 1f);
            }
           
            //  Destroy(gameObject, 2);
        }
    }
    public void GetPanelLoss()
    {
        Oj_canvas.Panel_endGame("Thử thách thất bại !",false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            p.isDie();
            GameManage.instance.end_game();
            Invoke(nameof(GetPanelLoss), 1f);
            
            //collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
