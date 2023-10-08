
using DG.Tweening;
using UnityEngine;

public class rainControll : MonoBehaviour
{
    Vector3 target;
    [SerializeField] private float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(transform.position.x - 5, -13, 0);
        transform.DORotate(new Vector3(0, 0, -25), 0.5f, RotateMode.FastBeyond360);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, target, Time.deltaTime * maxSpeed);
        Destroy(gameObject, 9f);
    }
}

