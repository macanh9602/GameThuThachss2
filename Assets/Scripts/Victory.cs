using DG.Tweening;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private Animator Oj_animator;
    [SerializeField] private Transform Oj_transform;
    [SerializeField] private SpriteRenderer Oj_sprite;
    [SerializeField] private CanVas Oj_canvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Oj_animator.SetBool("isVictory", true);
            GameManage.instance.end_game();
            Oj_transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 3f);
            Invoke(nameof(GetPanelWin), 1f);
        }
    }
   
    public void GetPanelWin()
    {
        Oj_canvas.Panel_endGame("Chúc mừng bạn đã qua thử thách !",true); 
    }
}
