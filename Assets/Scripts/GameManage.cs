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
    public bridgeControll bridgeControl;
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
        for (int i=0;i<gameObjectHidden.Length;i++)
        {
            gameObjectHidden[i].SetActive(true);
        }
        for (int i = 0; i < gameObjectAppear.Length; i++)
        {
            gameObjectAppear[i].SetActive(false);
        }
    }
    public void end_game()
    {
        isPlay = false;
    }
}
