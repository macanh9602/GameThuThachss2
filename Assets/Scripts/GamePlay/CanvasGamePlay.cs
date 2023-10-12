using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGamePlay : MonoBehaviour
{
    [SerializeField] private GameObject panel_gameMode;
    [SerializeField] private GameObject gameName;
    private int index_Scene = -1;
    public void playNow()
    {
        panel_gameMode.SetActive(true);
        gameName.SetActive(false);
    }
    public void setSelectGame(int index)
    {
        index_Scene = index;
        StartCoroutine(LoadGameSceneCoroutine());
    }

    public void Exit()
    {
        panel_gameMode.SetActive(false);
        gameName.SetActive(true);
    }

    // Coroutine để chuyển scene sau một khoảng thời gian đợi.
    IEnumerator LoadGameSceneCoroutine()
    {
        // Thực hiện các hành động cần thiết trước khi chuyển scene (nếu cần).
        Debug.Log("Preparing to load the game scene...");

        // Đợi một khoảng thời gian (ví dụ: 2 giây).
        yield return new WaitForSeconds(2f);

        // Chuyển đến scene "GameScene".
        SceneManager.LoadScene(index_Scene);
    }
}
