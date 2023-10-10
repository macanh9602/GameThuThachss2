using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Exctensions : MonoBehaviour
{
    public TMP_Text text;
   // bool IncomingText = false;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke(hello(), 3f);
        text = GetComponent<TMP_Text>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ChangeText(text, 2f, RandomText());
            //text.TextAnimationByMac(RandomText());

        }


    }
    private string RandomText()
    {
        string a = "";
        for (int i = 0; i < 6; i++)
        {
            a += Random.Range(0, 9);
        }
        return a;
    }




    // Update is called once per frame

}



//Tự tạo phương thức . note : this ,default
//overiding : cùng tên khác tham số 
//overload : cùng tên khác số lượng , khác kiểu , khác thứ tự sắp xếp