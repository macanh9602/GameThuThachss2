using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CanVas : MonoBehaviour
{
    public Text txtChucMung,txtThatbai; // Tham chiếu đến thành phần Text cần thay đổi nội dung.
    public void setTxtWin()
    {
        txtChucMung.DOText("Chúc mừng bạn đã qua thử thách !", 2f, true) // Văn bản ban đầu và thời gian hoàn thành tween.
           .SetDelay(1f);
    }
    public void setTxtLoss()
    {
        txtThatbai.DOText("Thử thách thật bại !", 2f, true) // Văn bản ban đầu và thời gian hoàn thành tween.
           .SetDelay(1f);
    }
}
