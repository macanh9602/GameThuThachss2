using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vectorDistance = (target.position - transform.position).normalized;
        //Debug.Log(vectorDistance.ToString());
        float ZRotation = -Mathf.Atan2(vectorDistance.x,vectorDistance.y)*Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0, 0, ZRotation);
    }
}
