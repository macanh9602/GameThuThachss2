﻿
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class CanVas : MonoBehaviour
{
    [SerializeField] private Text txtHeader,txtTopPlayer,txtPlayer; // Tham chiếu đến thành phần Text cần thay đổi nội dung.
    [SerializeField] private GameObject panel_end,panel_start,panel_pause ;
    [SerializeField] ScoreControll Score;
    [SerializeField] private TMP_InputField textPlayer;
    string t_Player, t_TopPlayer;
    public void btn_play()
    {
        panel_start.SetActive(false);
        panel_end.SetActive(false);
        panel_pause.SetActive(false);
        GameManage.instance.play_game();
    }
    public void btn_menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void btn_newGame()
    {  
        panel_start.SetActive(true);
        panel_end.SetActive(false);
        Time.timeScale = 1f;
    }
    public void btn_pause()
    {
        panel_pause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void btn_continue()
    {
        Time.timeScale = 1f;
        panel_pause.SetActive(false);
    }
    public void Panel_endGame(string text,bool winOrLoss)
    {
        panel_end.SetActive(true);
        if (Score.score2 > PlayerPrefs.GetInt("topscore")&& winOrLoss==true)
        {
            PlayerPrefs.SetInt("topscore", Score.score2);
            PlayerPrefs.SetString("topname", textPlayer.text);
        }
         if (winOrLoss == false)
        {
            t_Player = "Player: " + textPlayer.text + " " + 0;
        }
        else
        {
            t_Player = "Player: " + textPlayer.text + " " + Score.score2;
        }
        t_TopPlayer = "Top Player: " + PlayerPrefs.GetString("topname")+"  " + PlayerPrefs.GetInt("topscore");
        txtHeader.DOText(text, 1f, true) // Văn bản ban đầu và thời gian hoàn thành tween.
          .SetDelay(0.1f);
        txtTopPlayer.DOText(t_TopPlayer, 1f, true) // Văn bản ban đầu và thời gian hoàn thành tween.
          .SetDelay(0.1f);
        txtPlayer.DOText(t_Player, 1f, true) // Văn bản ban đầu và thời gian hoàn thành tween.
          .SetDelay(0.1f);
    }
    public void btn_newGameScene2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
}
