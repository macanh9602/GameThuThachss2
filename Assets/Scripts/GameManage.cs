using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static GameManage instance;
    public bool isPlay;
    public GameObject[] gameObjectHidden;
    public GameObject[] gameObjectAppear;
    public ScoreControll scoreControll;
    public playerControll player;
    private void Awake()
    {   if(instance==null)
        {
            instance = this;
        }
        isPlay = false;
    }

    public void play_game()
    {
        isPlay = true;

        player.ResetPlayer();
        scoreControll.ResetScore();
        for (int i = 0; i < gameObjectHidden.Length; i++)
        {
            gameObjectHidden[i].SetActive(true);
        }
        for (int i = 0; i < gameObjectAppear.Length; i++)
        {
            gameObjectAppear[i].SetActive(false);
        }
        GameObject ob_Elevator = GameObject.Find("Elevator(Clone)");
        if (ob_Elevator != null) { Destroy(ob_Elevator); }
        else { Debug.Log("khong tim thay Elevator(Clone)"); }
        GameObject ob_FlyingBoard = GameObject.Find("flyingBoard(Clone)");
        if (ob_FlyingBoard) { Destroy(ob_FlyingBoard); } 
        else { Debug.Log("khong tim thay flyingBoard(Clone)"); }

        bridgeControll[] bridges = FindObjectsOfType<bridgeControll>();
        for (int i=0; i<bridges.Length; i++)
        {
            bridges[i].destroy();
        }
    }
    public void end_game()
    {
        isPlay = false;
    }
}
