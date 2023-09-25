using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CongTac : MonoBehaviour
{
    [SerializeField] GameObject[] _target;
    bool _isActive = false;
    [SerializeField] Ease ease;
    Transform den;
    // Start is called before the first frame update
    void Start()
    {

        den = transform.Find("Den").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" && _isActive == false)
        {
            Debug.Log("cham player");
            den.DOShakeScale(1f);
            den.GetComponent<SpriteRenderer>().DOColor(Color.green, 2f).SetEase(ease).OnComplete(() =>
            {

                var sequence = DOTween.Sequence();
                foreach (var shap in _target)
                {
                    sequence.Append(shap.GetComponent<SpriteRenderer>().DOFade(1f, 0.1f).OnComplete(() =>
                    shap.gameObject.GetComponent<BoxCollider2D>().isTrigger = false));
                    sequence.Append(shap.transform.DOMoveY(-5.7f, 0.1f)).SetEase(Ease.InOutBounce);
                }
                sequence.Play();
            });

            _isActive = true;
        }
    }
}
