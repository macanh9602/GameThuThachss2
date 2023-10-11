using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RotateObj : MonoBehaviour
{
    [SerializeField] float duration = 3f;
    [SerializeField] Ease ease;
    [SerializeField] Vector3 end;
    [SerializeField] LoopType loopType;
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(end, duration, RotateMode.FastBeyond360).SetEase(ease).SetLoops(-1, loopType).SetRelative();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
