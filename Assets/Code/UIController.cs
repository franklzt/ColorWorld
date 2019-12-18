using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{

    public Image colorPrefab;
    public Transform parent;

    public Text infoText;

    int currentIndex = 255;

    public Button hintBtn;
    Text hintBtnText;

    void Start()
    {
        float greyColor = 0.0f;
        for (int i = 0; i < 256; i++)
        {
            Image tempImage = Instantiate(colorPrefab, parent);
            greyColor = i / 255.0f;
            tempImage.color = new Color(greyColor, greyColor, greyColor, 1.0f);
            tempImage.name = i.ToString();
            Button tempBtn = tempImage.GetComponent<Button>();
            if (tempBtn)
            {
                tempBtn.onClick.AddListener(ChoiceFeedBack);
            }

            Text tempText = tempImage.GetComponentInChildren<Text>();
            if(tempText != null)
            {
                tempText.text = i.ToString();
                float textColorIndex = 0.0f;

                if (i < 128)
                {
                    textColorIndex = 1;
                }
                else
                {
                    textColorIndex = 0;
                }

                tempText.color = new Color(textColorIndex, textColorIndex, textColorIndex, 1.0f);
            }
        }

        ShowText(-1, true);

        hintBtnText = hintBtn.GetComponentInChildren<Text>();
        hintBtn.onClick.AddListener(ShowHint);

        ClearBtnText();
    }


    void ShowHint()
    {
        ShowBtnText();
    }

    void ShowBtnText()
    {
        hintBtnText.text = currentIndex.ToString();
    }

    void ClearBtnText()
    {
        hintBtnText.text = "Get Hint";
    }



    public void NextColorBtn(Image targetImage)
    {
        currentIndex = Random.Range(0, 256);
        float targetColor = currentIndex / 255.0f;
        targetImage.color = new Color(targetColor, targetColor, targetColor, 1.0f);
        ShowText(-1, true);
        ClearBtnText();
    }


    void ShowText(int index,bool clearText)
    {
        if (clearText)
        {
            infoText.text = "Choose Color";
        }
        else
        {
            string info = index == currentIndex ? "Correct" : "Wrong";
            infoText.text = info;
        }       
    }


    public void ChoiceFeedBack()
    {
        GameObject selectGo = EventSystem.current.currentSelectedGameObject;
        int index = -1;
        if(int.TryParse(selectGo.name,out index)){
            ShowText(index, false);
        }
    }


}
