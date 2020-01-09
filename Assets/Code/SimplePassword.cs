using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimplePassword : MonoBehaviour
{

    public InputField inputString;
    public Text resultText;

    void Start()
    {
        inputString.text = "I LOVE YOU";
        resultText.text = GetResult(inputString.text);
        inputString.onEndEdit.AddListener((inputValue) =>
        {
            resultText.text = GetResult(inputValue);
        });
    }

    string GetResult(string inputString)
    {
        string[] keys = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "N", "M", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        Dictionary<string, int> data  = new Dictionary<string, int>();

        for (int i = 0; i < keys.Length; i++)
        {
            data.Add(keys[i], i);
        }

        string result = "";
        for (int i = 0; i < inputString.Length; i++)
        {
            if (data.ContainsKey(inputString[i].ToString()))
            {
                var tempValue = data[inputString[i].ToString()];
                result += tempValue + ",";
            }
           
        }
        result = result.Remove(result.Length - 1, 1);
        return result;
    }
}
