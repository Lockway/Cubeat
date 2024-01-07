using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMaker : MonoBehaviour
{
    public GameObject notePrefabRed, notePrefabGreen, notePrefabBlue;
    public GameObject notePrefabYellow, notePrefabCyan, notePrefabMagenta, notePrefabWhite;
    public GameObject noteHolder;

    System.Random random = new System.Random();

    private List<List<int>> noteScore;
    private int[] randomTable = { 2, 1, 0, 1, 0, 2, 0, 2, 1, 2, 0, 1, 0, 1, 2, 1, 2, 0 };

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        noteScore = GameSettings.NoteScore;
        GameObject[] notePrefab = 
        {
            notePrefabRed, notePrefabGreen, notePrefabBlue,
            notePrefabYellow, notePrefabCyan, notePrefabMagenta, notePrefabWhite
        };

        int noteAmount = 0;
        int ranNum = random.Next(0, 6);
        int[] lanePosition = { -140, 0, 140 };
        // Init

        foreach (var note in noteScore)
        {
            int noteColor = NoteParser.color_calc(note[0]);
            int noteLane = NoteParser.lane_calc(note[0]);
            // Init
            

            if (GameSettings.GameMode == 1) noteLane = 2 - noteLane;
            // Mirror
            if (GameSettings.GameMode == 2 || GameSettings.GameMode == 4)
            {
                noteLane = randomTable[ranNum * 3 + noteLane];
            }
            // Lane Random
            if (GameSettings.GameMode == 3 || GameSettings.GameMode == 4)
            {
                noteColor = RandomColor(noteColor, ranNum);
            }
            // Color Random


            bool noteRemain = true;
            int color_to_show = noteColor;

            while (noteRemain)
            {
                GameObject noteObject = Instantiate(notePrefab[color_to_show], noteHolder.transform);
                

                noteObject.transform.localPosition = new Vector3(lanePosition[noteLane], (float)note[1] * GameSettings.HighSpeed / 10, -5000);
                noteObject.SetActive(true);
                noteAmount++;
                // Making a note

                NoteObject noteScript = noteObject.AddComponent<NoteObject>();
                noteScript.noteTime = note[1];
                // Set variables in note

                if (noteColor < 3)
                {
                    noteRemain = false;
                    noteScript.keyToPress = KeyCode.Keypad7 - 3 * noteColor + noteLane;
                }
                else if(noteColor < 6)
                {
                    noteScript.keyToPress = KeyCode.Keypad7 - 3 * (noteColor - 3) + noteLane;
                    noteColor = (noteColor + 1) % 3;
                    // 3=0+1, 4=1+2, 5=2+0
                }
                else
                {
                    noteScript.keyToPress = KeyCode.Keypad1 + noteLane;
                    noteColor = 3;
                    // White = Blue + Yellow
                }

                int keynum = noteScript.keyToPress - KeyCode.Keypad1;
                GameManager.instance.notesInLane[keynum].Enqueue(noteObject);
                // Queueing
            }
        }
        GameManager.instance.maxCombo = noteAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int ColorMixer(int a,int b)
    {
        if (a + b == 1) return 3;
        else if (a + b == 3) return 4;
        else if (a + b == 2) return 5;
        else return -1;
    }

    int RandomColor(int c, int seed)
    {
        if (c < 3) return randomTable[seed * 3 + c];
        else if (c == 3)
        {
            int a = randomTable[seed * 3];
            int b = randomTable[seed * 3 + 1];
            return ColorMixer(a, b);
        }
        else if (c == 4)
        {
            int a = randomTable[seed * 3 + 1];
            int b = randomTable[seed * 3 + 2];
            return ColorMixer(a, b);
        }
        else if (c == 5)
        {
            int a = randomTable[seed * 3];
            int b = randomTable[seed * 3 + 2];
            return ColorMixer(a, b);
        }
        else return 6;
    }
}
