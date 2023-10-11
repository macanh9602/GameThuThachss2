using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasGamePlay : MonoBehaviour
{
    [SerializeField] private Sprite[] ob_layer;
    [SerializeField] private GameObject panel_gameMode,loadTime, panel_maintenance;
    private int index_Scene = -1,time=3;
    public void playNow()
    {
        panel_gameMode.SetActive(true);
    }
   IEnumerator maintenance()
    {
        panel_maintenance.SetActive(true);
        yield return new WaitForSeconds(1f);
        panel_maintenance.SetActive(false);
    }
    public void setSelectGame(int index)
    {
        if (index > 2)
        {
            StartCoroutine(maintenance());
        }
        else
        {
            index_Scene = index;
            panel_gameMode.SetActive(false);
            loadTime.SetActive(true);
            InvokeRepeating(nameof(loadTiming), 0, 1);
        }
       
      
    }
    public void loadTiming()
    {
        if (time < 0)
        {
            CancelInvoke(nameof(loadTiming));
            LoadGameScene();
            return;
        }
        loadTime.GetComponent<Image>().sprite = ob_layer[time];
        time -= 1;
        
    }
    public void Exit()
    {
        panel_gameMode.SetActive(false);
    }

    // Coroutine để chuyển scene sau một khoảng thời gian đợi.
    public void LoadGameScene()
    {
        // Chuyển đến scene "GameScene".
        SceneManager.LoadScene(index_Scene);
    }
}
