using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowLevel : MonoBehaviour
{
    public int option;
    private TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string levels = GameSettings.songLevels[GameSettings.CurrentSong];
        string[] parts = levels.Split(new char[] { ':' });

        textComponent.text = parts[option + 1];
    }
}
