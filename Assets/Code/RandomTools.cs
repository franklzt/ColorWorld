using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTools 
{
    public  static void KnuthDurstenfeldShuffle<T>(List<T> list)
    {
        //随机交换
        int currentIndex;
        T tempValue;
        for (int i = 0; i < list.Count; i++)
        {
            currentIndex = Random.Range(0, list.Count - i);
            tempValue = list[currentIndex];
            list[currentIndex] = list[list.Count - 1 - i];
            list[list.Count - 1 - i] = tempValue;
        }
    }

    public static void ArrrayDurstenfeldShuffle(int[] list)
    {
        //随机交换
        int currentIndex;
        int tempValue;
        for (int i = 0; i < list.Length; i++)
        {
            currentIndex = Random.Range(0, list.Length - i);
            tempValue = list[currentIndex];
            list[currentIndex] = list[list.Length - 1 - i];
            list[list.Length - 1 - i] = tempValue;
        }
    }
}
