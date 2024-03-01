using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public GameObject PrefabColorful, PrefabFast, PrefabSlow, PrefabMiss;
    public GameObject NoteButton;

    private void Awake()
    {
        instance = this;
    }

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

            if (GameSettings.GameMode == 5)
            {
                if (noteScript.transform.position.y <= -3.11)
                {
                    GameManager.instance.judges[0]++;
                    judgeEffect(0);
                    
                    GameManager.instance.NoteHit(i, 2);
                    if (noteScript.isLongNt)
                    {
                        noteScript.isLongNtClicked = true;
                    }
                    else
                    {
                        Destroy(currentNote);
                    }
                }
                continue;
            }   // Auto Play
            
            if (!noteScript.canBePressed)
            {
                if (timing - GameSettings.JudgeTiming.Miss <= musicTime && musicTime <= timing + GameSettings.JudgeTiming.Good)
                {
                    noteScript.canBePressed = true;
                }
            }
            else
            {
                if (timing + GameSettings.JudgeTiming.Good < musicTime)
                {
                    noteScript.canBePressed = false;
                    
                    GameManager.instance.judges[3]++;
                    judgeEffect(3);
                    GameManager.instance.NoteMiss(i);

                    if (noteScript.isLongNt)
                    {
                        GameManager.instance.judges[3]++;
                    }

                    Destroy(currentNote);
                }
            }
            // Transition of canBePressed


            if (Input.GetKeyDown(KeyCode.Keypad1 + i) || Input.GetKeyDown(GameManager.instance.mainToSubKey(i)))
            {
                if (noteScript.canBePressed)
                {
                    bool hit = true;
                    int judgeLevel = 0;

                    if (timing - GameSettings.JudgeTiming.Miss <= musicTime && musicTime <= timing - GameSettings.JudgeTiming.Good)
                    {
                        hit = false;
                        judgeEffect(3);
                        GameManager.instance.judges[3]++;
                    } // Bad
                    else if (timing - GameSettings.JudgeTiming.Good <= musicTime && musicTime <= timing - GameSettings.JudgeTiming.Perfect)
                    {
                        judgeLevel = 1;
                        GameManager.instance.judges[1]++;
                        judgeEffect(1);
                    } // Fast
                    else if (timing + GameSettings.JudgeTiming.Perfect <= musicTime && musicTime <= timing + GameSettings.JudgeTiming.Good)
                    {
                        judgeLevel = 1;
                        GameManager.instance.judges[2]++;
                        judgeEffect(2);
                    } // Slow
                    else
                    {
                        judgeLevel = 2;
                        GameManager.instance.judges[0]++;
                        judgeEffect(0);
                    } // Colorful

                    if (hit)
                    {
                        GameManager.instance.NoteHit(i, judgeLevel);
                        if (noteScript.isLongNt)
                        {
                            noteScript.isLongNtClicked = true;
                        }
                    }
                    else
                    {
                        GameManager.instance.NoteMiss(i);
                        if (noteScript.isLongNt)
                        {
                            GameManager.instance.judges[3]++;
                            judgeEffect(3); 
                            Destroy(currentNote);
                        }
                    }

                    if(!noteScript.isLongNt) Destroy(currentNote);
                }
            }
            // Checking Key Pressing
        }
    }

    public void judgeEffect(int option)
    {
        GameObject[] judgePrefab =
        {
            PrefabColorful, PrefabFast, PrefabSlow, PrefabMiss
        };

        GameObject judgeObject = Instantiate(judgePrefab[option], NoteButton.transform);
        judgeObject.transform.localPosition = new Vector3(0, 120, -5000);
        
        judgeObject.AddComponent<ShowJudge>();
        judgeObject.SetActive(true);
    }
}
