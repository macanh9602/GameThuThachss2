using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class textHD : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    // Start is called before the first frame update
    float n = 0;
    void Start()
    {
        text.text = "Hello người chơi (Ấn enter để tiếp tục)";
    }

    // Update is called once per frame
    void Update()
    {
        if (n == 0 && (Input.GetKeyDown(KeyCode.Return)))
        {
            text.TextAnimationByMDA("Ấn A/D để di chuyển");
            n = 1;
        }
        if (n == 1 && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            text.TextAnimationByMDA("Ấn space để nhảy ");
            n = 2;
        }
        if (n == 2 && (Input.GetKeyDown(KeyCode.Space)))
        {
            text.TextAnimationKillByMDA("chuc ban choi game vui ve");
            n = 3;
        }
    }
}
