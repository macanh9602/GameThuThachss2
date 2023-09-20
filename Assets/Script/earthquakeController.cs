using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class earthquakeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOShakePosition(3f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
