using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowLevel : MonoBehaviour
{
    public int option;
    private int[] tenPow = { 1, 10, 100 };
    private int levels, level;
    private TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        levels = GameSettings.songLevels[GameSettings.CurrentSong];
        level = (levels / tenPow[option]) % 10;

        textComponent.text = level != 0 ? level.ToString() : " ";
    }
}
