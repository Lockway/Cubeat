using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteMaker : MonoBehaviour
{
    public Sprite noteRed, noteGreen, noteBlue;
    public Sprite noteYellow, noteCyan, noteMagenta, noteWhite;
    public Sprite longNoteRed, longNoteGreen, longNoteBlue;
    public Sprite longNoteYellow, longNoteCyan, longNoteMagenta, longNoteWhite;
    public GameObject noteHolder;
    public float noteHeight;

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
        Sprite[] notePrefab = 
        {
            noteRed, noteGreen, noteBlue,
            noteYellow, noteCyan, noteMagenta, noteWhite
        };
        Sprite[] longNotePrefab =
        {
            longNoteRed, longNoteGreen, longNoteBlue,
            longNoteYellow, longNoteCyan, longNoteMagenta, longNoteWhite
        };

        int noteAmount = 0;
        int ranNum = random.Next(0, 6);
        int[] lanePosition = { -140, 0, 140 };
        // Init

        foreach (var note in noteScore)
        {
            note[1] += GameSettings.NoteOffset + GameSettings.AudioLatency;
            note[3] += GameSettings.NoteOffset + GameSettings.AudioLatency;
            // Note Offset

            int noteColor = NoteParser.color_calc(note[0]);
            int noteLane = NoteParser.lane_calc(note[0]);
            int isLongNt = note[2];
            int longNtEndTime = note[3];
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
                GameObject noteObject = new GameObject("note");
                noteObject.transform.SetParent(noteHolder.transform, false);

                Image img = noteObject.AddComponent<Image>();

                RectTransform rect = img.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(118f, noteHeight);
                // Test

                if (isLongNt == 0)
                {
                    img.sprite = notePrefab[color_to_show];
                    
                    noteObject.transform.localPosition = new Vector3(lanePosition[noteLane],
                        (float)note[1] * GameSettings.HighSpeed / 10, -5000);
                }
                else
                {
                    img.sprite = longNotePrefab[color_to_show];
                    
                    var midY = (float)(note[3] + note[1]) / 2;
                    noteObject.transform.localPosition = new Vector3(lanePosition[noteLane],
                        midY * GameSettings.HighSpeed / 10, -4000);

                    var noteScale = noteObject.transform.localScale;
                    var val = ((note[3] - note[1]) * GameSettings.HighSpeed / 10 + noteHeight) * noteScale.y / noteHeight;
                    noteObject.transform.localScale = new Vector3(noteScale.x, (float)val, noteScale.z);
                }
                // Locating note
                
                
                noteObject.SetActive(true);
                noteAmount++;
                // Making a note


                NoteObject noteScript = noteObject.AddComponent<NoteObject>();
                noteScript.noteTime = note[1];
                if (isLongNt == 1)
                {
                    noteScript.isLongNt = true;
                    noteScript.longNtEndTime = longNtEndTime;
                    noteAmount++;
                }
                // Set variables in note
                
                KeyCode keyToPress;
                if (noteColor < 3)
                {
                    noteRemain = false;
                    keyToPress = KeyCode.Keypad7 - 3 * noteColor + noteLane;
                }
                else if(noteColor < 6)
                {
                    keyToPress = KeyCode.Keypad7 - 3 * (noteColor - 3) + noteLane;
                    noteColor = (noteColor + 1) % 3;
                    // 3=0+1, 4=1+2, 5=2+0
                }
                else
                {
                    keyToPress = KeyCode.Keypad1 + noteLane;
                    noteColor = 3;
                    // White = Blue + Yellow
                }

                int keyNum = keyToPress - KeyCode.Keypad1;
                noteScript.keyNum = keyNum;
                GameManager.instance.notesInLane[keyNum].Enqueue(noteObject);
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
