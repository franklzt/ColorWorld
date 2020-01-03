using UnityEngine;
using UnityEngine.UI;

public class MusicNameController : MonoBehaviour
{
    public MusicItem prefab;
    public Transform rootParent;
    public Text randomText;
    public Button nextGenerateBtn;
    public Button toggleRootBtn;

    string[] musicNames = { "C", "D", "E", "F", "G", "A", "B" };
    string[] numberNames = { "1", "2", "3", "4", "5", "6", "7" };
    string[] singNames = { "Do", "Re", "Mi", "Fa", "Sol", "La", "Si" };

    
    void Start()
    {
        nextGenerateBtn.onClick.AddListener(() =>
        {
            GenerateText();
        });

        toggleRootBtn.onClick.AddListener(()=>
        {
            rootParent.gameObject.SetActive(!rootParent.gameObject.activeInHierarchy);
        });


        for (int i = 0; i < 7; i++)
        {
            MusicItem musicItem = Instantiate<MusicItem>(prefab, rootParent);
            musicItem.musicName.text = musicNames[i];
            musicItem.numberName.text = numberNames[i];
            musicItem.singName.text = singNames[i];
        }
        GenerateText();
    }

    void GenerateText()
    {
        int random = Random.Range(0, 7);
        randomText.text = numberNames[random];
    }
}
