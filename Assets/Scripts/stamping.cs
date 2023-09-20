using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class stamping : MonoBehaviour
{
    private Tweener stampingAction;
    // Start is called before the first frame update
    void Start()
    {
        stampingAction = transform.DOMoveY(transform.position.y + 2, 1).SetLoops(-1,LoopType.Yoyo);
        stampingAction.Play();
    }
}
