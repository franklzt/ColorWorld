using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomItem : MonoBehaviour
{
    public Text randomText;
    public RectTransform dotTrans;

    public void UpdateText(string number,int position = 0)
    {
        dotTrans.gameObject.SetActive(true);
        Vector3 localPositon = dotTrans.localPosition;
        switch (position)
        {
            case -1:
                localPositon.y = -25;
                dotTrans.localPosition = localPositon;
                break;
            case 0:
                dotTrans.gameObject.SetActive(false);
                break;
            case 1:
                localPositon.y = 25;
                dotTrans.localPosition = localPositon;

                break;
            default:
                break;
        }

        randomText.text = number;
    }
}
