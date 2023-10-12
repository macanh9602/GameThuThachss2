using DG.Tweening;
using UnityEngine;

public class GearControll : MonoBehaviour
{
    Tweener tweener;
    [SerializeField] private Vector3 target;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float time;
    // Start is called before the first frame update
    private int flat = 1;
    void Start()
    {
        if (transform.position.x < 0)
        {
           flat = -1;
        }
        InvokeRepeating(nameof(gearActive),0f, time+1);
        transform.DORotate(new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
    }
    void gearActive()
    {
        tweener =  transform.DOMoveX(transform.position.x + (target.x*flat*(-1)), time).SetEase(Ease.Linear);
        transform.localScale = new Vector3((-1) * transform.localScale.x , transform.localScale.y, transform.localScale.z);
        if(flat == 1)
        {
            sprite.DOColor(new Color(Random.Range(0.0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f),1), time);
        }
        else
        {
            sprite.DOColor(new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1), time);
        }
        flat *= -1;
    }
}
