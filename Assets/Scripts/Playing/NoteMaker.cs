using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMaker : MonoBehaviour
{
    public GameObject notePrefabRed, notePrefabGreen, notePrefabBlue, notePrefabYellow, notePrefabCyan, notePrefabMagenta, notePrefabWhite;
    public GameObject noteHolder;
    private List<List<int>> noteScore;
    
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        noteScore = GameSettings.noteScore;
        GameObject[] notePrefab = 
        {
            notePrefabRed, notePrefabGreen, notePrefabBlue, notePrefabYellow, notePrefabCyan, notePrefabMagenta,
            notePrefabWhite
        };
        int[] lanePosition = { -140, 0, 140 };
        

        foreach (var note in noteScore)
        {
            int noteColor = NoteParser.color_calc(note[0]);
            int noteLane = NoteParser.lane_calc(note[0]);

            GameObject noteObject = Instantiate(notePrefab[noteColor], noteHolder.transform);
            noteObject.transform.localPosition = new Vector3(lanePosition[noteLane], (float)note[1], -5000);
            noteObject.SetActive(true);
        }
        
        // GameObject testNote1 = Instantiate(notePrefabA, noteHolder.transform);
        // testNote1.transform.localPosition = new Vector3(-140, 50, -5000);
        // testNote1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
