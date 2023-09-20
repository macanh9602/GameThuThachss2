using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private Animator Oj_animator;
    [SerializeField] private Transform Oj_tranform;
    [SerializeField] private SpriteRenderer Oj_sprite;
    [SerializeField] private GameObject Panel_win;
    [SerializeField] private CanVas Oj_canvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Oj_animator.SetBool("isVictory", true);
            Invoke(nameof(DesTroyPlayer),0.5f);
        }
    }
    void DesTroyPlayer()
    {
      //  Oj_tranform = transform;
        Oj_sprite.DOFade(0, 3f);
        Oj_tranform.DOScale(new Vector3(0, 0, 0), 3f);
        Invoke(nameof(GetPanelWin), 1f);

    }
    public void GetPanelWin()
    {
        Panel_win.SetActive(true);
        Oj_canvas.setTxtWin(); 
    }
}
