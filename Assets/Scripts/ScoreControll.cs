
using UnityEngine;
using UnityEngine.UI;

public class ScoreControll : MonoBehaviour
{
    [SerializeField] private CanVas Oj_canvas;
    public Sprite[] Image;
    public GameObject[] Layer_Object = new GameObject[5];
    public int Inputscore = 9, score2;
    int index1,index2,index3,score1;
    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
    }
    public void ResetScore()
    {
        if(GameManage.instance.isPlay)
        {
            score1 = Inputscore;
            score2 = Inputscore;
            CancelInvoke(nameof(ChangeSprite));
            InvokeRepeating(nameof(ChangeSprite), 0, 0.5f);
        }
    }
    void ChangeSprite()
    {
       index1 = score1 / 100;
        score1 %= 100;
        index2 = score1 / 10;
        score1 %= 10;
        index3 = score1;
        if (score2 < 0)
        {
            Oj_canvas.Panel_endGame("Thu thach that bai !",false);
            CancelInvoke(nameof(ChangeSprite));
        }
        Layer_Object[0].GetComponent<Image>().sprite = Image[index1];
        Layer_Object[1].GetComponent<Image>().sprite = Image[index2];
        Layer_Object[2].GetComponent<Image>().sprite = Image[index3];
        score2 -= 1;
        score1 = score2;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
