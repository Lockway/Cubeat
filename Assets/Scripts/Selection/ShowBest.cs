using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowBest : MonoBehaviour
{
    public int option;
    private int scoreBest, pos, diff;
    private string scoreRank;
    private TextMeshProUGUI currentText;

    // Start is called before the first frame update
    void Start()
    {
        currentText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        diff = GameSettings.Difficulty;
        pos = GameSettings.CurrentSong * 3 + diff;

        if (option == 0)
        {
            scoreBest = GameSettings.songBests[pos];
            currentText.text = scoreBest.ToString("D7");
        }
        else
        {
            scoreRank = GameSettings.songRanks[pos];
            currentText.text = scoreRank;
        }
    }
}
