using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Ease ease;
    [SerializeField] Transform bullet;

    [SerializeField] Transform bulletSpawnPoint;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotationGun();

        timer += Time.deltaTime;
        if(timer > 2f)
        {
            Fire();
            timer = 0;
        }
        Debug.Log(timer);
    }

    private void RotationGun()
    {
        Vector2 vectorDistance = (target.position - transform.position).normalized;
        //Debug.Log(vectorDistance.ToString());
        float ZRotation = -Mathf.Atan2(vectorDistance.x, vectorDistance.y) * Mathf.Rad2Deg;
        transform.DORotateQuaternion(Quaternion.Euler(0, 0, ZRotation),0.5f).SetEase(ease);
        //transform.rotation = Quaternion.Euler(0, 0, ZRotation);
    }

    public void Fire()
    {
        GameObject bullet1 = Instantiate(bullet.gameObject, bulletSpawnPoint.position, Quaternion.identity);
        float distance = (target.position - transform.position).magnitude;
        bullet1.transform.DOMove(target.position, 0.1f* distance).OnComplete(() => {
            Destroy(bullet1);
        });
    }

}
