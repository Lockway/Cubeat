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
        

        foreach (var note in noteScore)
        {
            int noteColor = NoteParser.color_calc(note[0]);
            int color_to_show = noteColor;
            int noteLane = NoteParser.lane_calc(note[0]);
            bool noteRemain = true;

            while (noteRemain)
            {
                noteAmount++;
                GameObject noteObject = Instantiate(notePrefab[color_to_show], noteHolder.transform);

                noteObject.transform.localPosition = new Vector3(lanePosition[noteLane], (float)note[1], -5000);
                noteObject.SetActive(true);

                CircleCollider2D hitWindow = noteObject.AddComponent<CircleCollider2D>();
                hitWindow.radius = 1;

                NoteObject noteScript = noteObject.AddComponent<NoteObject>();
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
            }
        }

        GameManager.instance.maxCombo = noteAmount;
        // GameObject testNote1 = Instantiate(notePrefabA, noteHolder.transform);
        // testNote1.transform.localPosition = new Vector3(-140, 50, -5000);
        // testNote1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
