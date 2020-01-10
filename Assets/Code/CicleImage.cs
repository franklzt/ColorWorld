using UnityEngine;
using UnityEngine.UI;
public class CicleImage : MonoBehaviour
{
    public Sprite[] allSprite;
    public Button circleBtn;
    public Image targetImag;
    int currentSprite;
    void Start()
    {
        circleBtn.onClick.AddListener(()=>
        {
            currentSprite++;
            if(currentSprite >= allSprite.Length)
            {
                currentSprite = 0;
            }

            targetImag.sprite = allSprite[currentSprite];
        });        
    }

}
