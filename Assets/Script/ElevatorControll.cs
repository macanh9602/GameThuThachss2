using DG.Tweening;

using UnityEngine;

public class ElevatorControll : MonoBehaviour
{
    private int flat = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(ActiveElevator), 0, 3);

    }
    private void ActiveElevator()
    {
        transform.DOMoveY(transform.position.y + (6 * flat), 2).SetEase(Ease.Linear);
        flat *= -1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
