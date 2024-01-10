using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class NoteParser : MonoBehaviour
{
    private string songTitle;
    private string filepath;
    private string[] levels = { "Easy", "Normal", "Hard" };

    void Awake()
    {
        songTitle = GameSettings.songTitles[GameSettings.CurrentSong];
        filepath = Path.Combine(Application.dataPath, "Resources/Songs", songTitle, levels[GameSettings.Difficulty] + ".txt");
        
        List<string> lines = ReadFileAsList(filepath);
        GameSettings.NoteScore = noteReader(lines);
    }
    // Finding path of score

    List<string> ReadFileAsList(string filePath)
    {
        List<string> lines = new List<string>();

        if (File.Exists(filePath))
        {
            lines.AddRange(File.ReadAllLines(filePath));
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }

        return lines;
    }
    // File reading function

    List<List<int>> noteReader(List<string> lines)
    {
        List<List<int>> allNum = new List<List<int>>();

        foreach (string line in lines)
        {
            List<int> numbers = new List<int>();
            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Debug.LogError("Invalid number format: " + part);
                }
            }
            allNum.Add(numbers);
        }

        return allNum;
    }
    // Change to INT

    public class Note
    {
        public enum NoteColor { Red, Green, Blue, Yellow, Cyan, Magenta, White }
        public NoteColor Color { get; set; }
        public int Lane { get; set; }
        public int time { get; set; }
        public int type { get; set; }
        public int endtime { get; set; }
    }
    // Note class

    public static int color_calc(int x)
    {
        if (x < 10) return 0;
        else if (x < 100)
        {
            if (x % 10 == 0) return 1;
            else return 3;
        }
        else
        {
            if (x % 100 == 0) return 2;
            else if (x % 110 == 0) return 4;
            else if (x % 101 == 0) return 5;
            else return 6;
        }
    }
    // Return color number

    public static int lane_calc(int x)
    {
        int res;

        if (x % 10 != 0) res = x % 10;
        else if (x % 100 != 0) res = (x % 100) / 10;
        else res = x / 100;

        return res - 1;
    }
    // Return lane number



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
