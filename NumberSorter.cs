using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

public class NumberSorter : MonoBehaviour
{

    Button readFileButton, writeJSONButton;
    Text unsortedNumbers, sortedNumbers;

    string readFilePath = "Assets/Resources/Unsorted Numbers.txt";
    string writeFilePath = "Assets/Resources/Sorted Numbers.json";

    private void Start()
    {
        readFileButton = GameObject.Find("Read File Button").GetComponent<Button>();
        readFileButton.onClick.AddListener(ReadFile);

        writeJSONButton = GameObject.Find("Write JSON Button").GetComponent<Button>();
        writeJSONButton.onClick.AddListener(WriteJSON);

        unsortedNumbers = GameObject.Find("Unsorted Numbers").GetComponent<Text>();
        sortedNumbers = GameObject.Find("Sorted Numbers").GetComponent<Text>();
    }

    public int[] numbers;
    void ReadFile()
    {
        StreamReader reader = new StreamReader(readFilePath);
        numbers = Array.ConvertAll(
            // Reads file, splits into string[]
            reader.ReadToEnd().Split('\n'),
            // Parses string[] to int[]
            s=>int.Parse(s));

        reader.Close();

        unsortedNumbers.text = string.Join(", ", numbers);

        numbers = numbers.OrderBy(n => n).ToArray();

        sortedNumbers.text = string.Join(", ", numbers);
    }

    void WriteJSON()
    { 
        StreamWriter writer = new StreamWriter(writeFilePath);
        writer.Write(JsonUtility.ToJson(this));

        writer.Close();
    }
}
