using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] Ease ease;
    [SerializeField] Transform door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            transform.GetComponent<SpriteRenderer>().DOColor(Color.green, 2f).SetEase(ease).OnComplete(() => { 
                door.GetComponent<SpriteRenderer>().DOFade(0, 3f);
                door.gameObject.SetActive(false);
            }) ;
        }
    }
}
