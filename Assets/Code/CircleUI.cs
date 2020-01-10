using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct CircleData
{
    public int distance;
    public string[] textData;
    public bool showSongNames;
}



public class CircleUI : MonoBehaviour
{
    public Transform parent;
    public RectTransform prefabTrans;
    public float distance = 5;
    string[] songNames = new string[] {"1","2","3","4","5","6","7"};
    string[] fixedNames = new string[]{"C","D","E","F","G","A","B"};

    string[] circleNames = new string[] { "C", "G", "D", "A", "E", "B", "Gb","Db","Ab","Eb","Bb","F" };

    [SerializeField]
    public CircleData[] circleDatas;


    int GetIndex(string texts)
    {
        for (int i = 0; i < fixedNames.Length; i++)
        {
            if(texts == fixedNames[i])
            {
                return i;
            }
        }
        return -1;
    }


    void Start()
    {
        for (int i = 0; i < circleDatas.Length; i++)
        {
            SpawnCircle(circleDatas[i].distance, circleDatas[i].textData,circleDatas[i].showSongNames);
        }
    }


    void SpawnCircle(float newDistance,string[] texts,bool showSingName = false)
    {
        for (int i = 0; i < 12; i++)
        {
            var go = Instantiate(prefabTrans, parent);
            go.name = i.ToString();
            var targetAngle = Quaternion.Euler(new Vector3(0, 0, 360 - i * 30));
            var targetPostion = targetAngle * new Vector3(0, newDistance, 0);
            go.transform.localPosition = targetPostion;

            var tempResult = texts[i];
            if (showSingName)
            {
                var tempKeyName = tempResult[0].ToString();                 
                var tempSing = GetIndex(tempKeyName);
                if(tempSing >= 0)
                {
                    tempResult = songNames[tempSing];

                }
                else
                {
                    tempResult = texts[i];
                }
            }

            var tempTxt = go.GetComponent<Text>();
            tempTxt.text = tempResult;
        }
    }

}
