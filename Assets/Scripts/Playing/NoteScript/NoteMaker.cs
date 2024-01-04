using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMaker : MonoBehaviour
{
    public GameObject notePrefabRed, notePrefabGreen, notePrefabBlue, notePrefabYellow, notePrefabCyan, notePrefabMagenta, notePrefabWhite;
    public GameObject noteHolder;
    public int noteAmount;

    private List<List<int>> noteScore;
    
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        noteAmount = 0;
        noteScore = GameSettings.NoteScore;
        GameObject[] notePrefab = 
        {
            notePrefabRed, notePrefabGreen, notePrefabBlue, notePrefabYellow, notePrefabCyan, notePrefabMagenta,
            notePrefabWhite
        };
        
        int[] lanePosition = { -140, 0, 140 };
        // Init

        foreach (var note in noteScore)
        {
            int noteColor = NoteParser.color_calc(note[0]);
            int noteLane = NoteParser.lane_calc(note[0]);

            bool noteRemain = true;
            int color_to_show = noteColor;
            // Init

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
}
