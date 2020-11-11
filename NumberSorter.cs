using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

public class NumberSorter : MonoBehaviour
{
    public Button readFileButton;
    public Button writeJSONButton;
    public Text unsortedNumbers
    public Text sortedNumbers;

    public string readFilePath = "Assets/Resources/Unsorted Numbers.txt";
    public string writeFilePath = "Assets/Resources/Sorted Numbers.json";

    public JSONData data = new JSONData();
    
    private void Start()
    {
        readFileButton.onClick.AddListener(ReadFile);
        writeJSONButton.onClick.AddListener(WriteJSON);
    }

    private void ReadFile()
    {
        using(var reader = new StreamReader(readFilePath))
        {
            data.numbers = Array.ConvertAll(
                // Reads file, splits into string[]
                reader.ReadToEnd().Split('\n'),
                // Parses string[] to int[]
                s=>int.Parse(s));
        }

        unsortedNumbers.text = string.Join(", ", data.numbers);

        data.numbers = data.numbers.OrderBy(n => n).ToArray();

        sortedNumbers.text = string.Join(", ", data.numbers);
    }

    private void WriteJSON()
    { 
        using(var writer = new StreamWriter(writeFilePath))
        {
            writer.Write(JsonUtility.ToJson(data));
        }
    }
    
    [Serializable]
    public Class JSONData
    {
        public int[] numbers;
    }
}
