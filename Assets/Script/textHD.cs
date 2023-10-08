using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Unity.VisualScripting;

public class textHD : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] TMP_Text textInput;
    [SerializeField] GameObject BGtalk;
    // Start is called before the first frame update
    float n = 0;
    void Start()
    {
        BGtalk.gameObject.SetActive(true);
        text.text = "Halo people ! Welcomeback !";
        textInput.text = "--> Click Enter to countinue";
    }

    // Update is called once per frame
    void Update()
    {
        
        if (n == 0 && (Input.GetKeyDown(KeyCode.Return)))
        {
            text.TextAnimationByMDA("A/D to move");
            n = 1;
        }
        if (n == 1 && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            text.TextAnimationByMDA("Space to Jump");
            n = 2;
        }
        if (n == 2 && (Input.GetKeyDown(KeyCode.Space)))
        {
            text.TextAnimationKillByMDA("Goodjob ! Let's play !");
            n = 3;
        }
        if(n != 0)
        {
            textInput.text = "";
        }
    }
}
