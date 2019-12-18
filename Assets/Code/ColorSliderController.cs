using UnityEngine;
using UnityEngine.UI;

public class ColorSliderController : MonoBehaviour
{

    public ColorSlider[] colorSliders;
    public Color[] Colors;   
    public Image targetImage;


    float[] canvasColor;


    void Start()
    {

        canvasColor = new float[colorSliders.Length];

        for (int i = 0; i < colorSliders.Length; i++)
        {
            colorSliders[i].index = i;
            colorSliders[i].OnChangeSlider += ChangeSlider;
            colorSliders[i].InitData();
        }       
    }

    void ChangeSlider(float value, Slider target, Text slideText, int index)
    {
        target.fillRect.GetComponentInChildren<Image>().color = Colors[index] * value;
        target.handleRect.GetComponentInChildren<Image>().color = Colors[index];

        slideText.color = Colors[index];
        slideText.text = Mathf.FloorToInt((255.0f * value)).ToString();

        canvasColor[index] = value;
        targetImage.color = new Color(Colors[0].r * canvasColor[0], Colors[1].g * canvasColor[1], Colors[2].b * canvasColor[2], Colors[3].a * canvasColor[3]);
    }

}
