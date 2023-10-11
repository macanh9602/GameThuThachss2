using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class flyingBoard : MonoBehaviour
{
    public bool isMove;
    [SerializeField] private GameObject[] waypoint;
    [SerializeField] private float maxSpeed;
    private int currentWaypointIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        waypoint = new GameObject[2];
        waypoint[0] = GameObject.Find("pointstart");
        waypoint[1] = GameObject.Find("pointend");
        isMove = false;
    }
    void FixedUpdate()
    {

        if (isMove)
        {
            move();
        }   
    }
    public void move()
    {
        // tinh khoang cach giua FlyBroad va Diem ket thuc(hoac bat dau)
        if (Vector2.Distance(waypoint[currentWaypointIndex].transform.position, transform.position) < .1f)  
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoint.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoint[currentWaypointIndex].transform.position, Time.deltaTime * maxSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        isMove = true;
        collision.gameObject.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name =="Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
