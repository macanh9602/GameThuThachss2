using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RotateObj : MonoBehaviour
{
    [SerializeField] float duration = 3f;
    [SerializeField] Ease ease;
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(0, 0, 360), duration, RotateMode.FastBeyond360).SetEase(ease).SetLoops(-1, LoopType.Incremental);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
