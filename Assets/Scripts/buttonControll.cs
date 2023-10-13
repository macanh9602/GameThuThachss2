using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class buttonControll : MonoBehaviour
{
    [SerializeField] private Ease typeEasing;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(new Vector3(transform.localScale.x+0.1f, transform.localScale.y+0.1f, transform.localScale.z+0.3f),0.2f).
            SetLoops(-1,LoopType.Yoyo).SetEase(typeEasing);
    }
}
