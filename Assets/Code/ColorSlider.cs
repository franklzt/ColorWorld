using UnityEngine;
using UnityEngine.UI;

public delegate void ChangeSlider(float value,Slider target,Text text,int index);

public class ColorSlider : MonoBehaviour
{

    public Slider colorElement;
    public Text slideText;

    public ChangeSlider OnChangeSlider;
    public int index = 0;

    void Start()
    {
        colorElement.onValueChanged.AddListener((value) =>
        {
            if(OnChangeSlider != null)
            {
                OnChangeSlider.Invoke(value,colorElement,slideText,index);               
            }
        });
    }


    public void InitData()
    {
        if (OnChangeSlider != null)
        {
            OnChangeSlider.Invoke(0, colorElement, slideText, index);
        }
    }

}
