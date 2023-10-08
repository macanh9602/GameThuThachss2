using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpowBridge : MonoBehaviour
{
    public GameObject bridge_prefabs;
    private int bridge_number = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(bridge_spawn), 0, 0.2f);
    }
    void bridge_spawn()
    {
        GameObject oj = Instantiate(bridge_prefabs, new Vector3(12.6f - bridge_number, -9f, 0), Quaternion.identity);
        oj.transform.DOMoveY(-9.4f, 0.5f);
        if (bridge_number == 19) { CancelInvoke(nameof(bridge_spawn)); }
        bridge_number++;
    }
}
