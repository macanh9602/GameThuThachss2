using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowControll : MonoBehaviour
{
    Vector3 target;
    [SerializeField] private float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(transform.position.x-2,-13,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, target, Time.deltaTime * maxSpeed);
        Destroy(gameObject,12f);
    }
}
