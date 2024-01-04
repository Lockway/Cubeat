using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int[] subkeys = { 23, 2, 21, 18, 3, 5, 22, 4, 17 };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var musicTime = Mathf.RoundToInt(GameManager.instance.theMusic.time * 1000f);

        for (int i = 0; i < 9; i++)
        {
            if (GameManager.instance.notesInLane[i].Count == 0) continue;

            GameObject currentNote = GameManager.instance.notesInLane[i].Peek();
            NoteObject noteScript = currentNote.GetComponent<NoteObject>();
            int timing = noteScript.noteTime;
            // Init

            if (!noteScript.canBePressed)
            {
                if (timing - GameSettings.JudgeTiming.Good <= musicTime && musicTime <= timing + GameSettings.JudgeTiming.Good)
                {
                    noteScript.canBePressed = true;
                }
            }
            else
            {
                if (timing + GameSettings.JudgeTiming.Good < musicTime)
                {
                    noteScript.canBePressed = false;
                    if (!noteScript.hit)
                    {
                        GameManager.instance.NoteMiss(i);
                        GameManager.instance.judges[3]++;
                    }
                }
            }
            // Transition of canBePressed


            // if (Input.GetKeyDown(noteScript.keyToPress))

            if (Input.GetKeyDown(KeyCode.Keypad1 + i) || Input.GetKeyDown(KeyCode.A + subkeys[i]))
            {
                if (noteScript.canBePressed)
                {
                    noteScript.hit = true;

                    if (timing - GameSettings.JudgeTiming.Good <= musicTime && musicTime <= timing - GameSettings.JudgeTiming.Perfect)
                    {
                        GameManager.instance.judgeLevel = 1;
                        GameManager.instance.judges[1]++;
                    } // Fast
                    else if (timing + GameSettings.JudgeTiming.Perfect <= musicTime && musicTime <= timing + GameSettings.JudgeTiming.Good)
                    {
                        GameManager.instance.judgeLevel = 1;
                        GameManager.instance.judges[2]++;
                    } // Late
                    else
                    {
                        GameManager.instance.judgeLevel = 2;
                        GameManager.instance.judges[0]++;
                    } // Colorful

                    GameManager.instance.NoteHit(i);
                    Destroy(currentNote);
                }
            }
            // Checking Key Pressing
        }
    }
}
