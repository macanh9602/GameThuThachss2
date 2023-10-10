using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectControll : MonoBehaviour
{
    Vector3 target;
    [SerializeField] private float timeMove;
    [SerializeField] private float angle;
    [SerializeField] private float x;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(transform.position.x-x,-13,0);
        transform.DORotate(new Vector3(0, 0, angle), 0.5f, RotateMode.FastBeyond360);
        transform.DOMove(target, timeMove);
        Destroy(gameObject, timeMove+0.2f);
    }
}
