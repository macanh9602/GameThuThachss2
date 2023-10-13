using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class circle : MonoBehaviour
{
    public float radius = 2f; // Bán kính của đường tròn
    public float speed = 1f; // Tốc độ di chuyển
    private float angle = 0f; // Góc của vị trí hiện tại trên đường tròn
    public Vector3 center = new Vector3(0, 0, 0); // Tâm của đường tròn

    public void Start()
    {
        transform.DORotate(new Vector3(0,0,360), 1f, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);

    }
    void Update()
    {
        /*// Tính toán vị trí x và y trên đường tròn
        float x = center.x + Mathf.Cos(angle) * radius;
        float y = center.y + Mathf.Sin(angle) * radius;

        // Đặt vị trí của đối tượng thành vị trí trên đường tròn
        transform.position = new Vector3(x, y, center.z);

        // Tăng góc để di chuyển đối tượng theo đường tròn
        angle += speed * Time.deltaTime;

        // Đảo chiều hướng di chuyển khi đối tượng hoàn thành một chu kỳ
        if (angle >= 2 * Mathf.PI)
        {
            angle = 0f;
        }*/
    }
}

/*public float speed = 1f;
public float radius = 10f;

private float angle;

void Update()
{
    angle += speed * Time.deltaTime;

    float x = Mathf.Cos(angle) * radius;
    float y = Mathf.Sin(angle) * radius;

    transform.position = new Vector3(x, y, 0);
}*/