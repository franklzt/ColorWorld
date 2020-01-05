using System.Collections.Generic;
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

    public RandomItem randomItemPrefab;
    public Transform randomItemParent;
    string[] randomString = { "1", "2", "3", "4", "5", "6", "7", "1", "2", "3", "4", "5", "6", "7" ,"1", "2", "3", "4", "5", "6", "7"};

    List<RandomItem> randomItems = new List<RandomItem>();
    int[] shuffle;

    public Button generateButton;

    void InitRandomItems()
    {
        shuffle = new int[randomString.Length];
        for (int i = 0; i < randomString.Length; i++)
        {
            shuffle[i] = new int();
            shuffle[i] = i;
            RandomItem tempRandom = Instantiate(randomItemPrefab, randomItemParent);
            int positon = GetPosition(i);
            tempRandom.UpdateText(randomString[i], positon);
            randomItems.Add(tempRandom);
        }
    }

    int GetPosition(int index)
    {
        int positon = 0;
        if (index < 7)
        {
            positon = -1;

        }
        else if (index > 13)
        {
            positon = 1;
        }
        return positon;
    }

    void ReGenerate()
    {
        RandomTools.ArrrayDurstenfeldShuffle(shuffle);
        for (int i = 0; i < shuffle.Length; i++)
        {
            int index = shuffle[i];
            int position = GetPosition(index);
            randomItems[i].UpdateText(randomString[index], position);
        }
    }
    
    void Start()
    {
        InitRandomItems();

        generateButton.onClick.AddListener(() => {
            ReGenerate();
        });
        




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
