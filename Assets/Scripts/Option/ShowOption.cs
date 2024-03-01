using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowOption : MonoBehaviour
{
    public int option;
    private TextMeshProUGUI textComponent;
    private string[] gameModes = { "Normal Mode", "Mirror", "Lane Random", "Color Random", "Super Random", "Auto Play" };

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (option == 0)
        {
            textComponent.text = "High Speed  " + GameSettings.HighSpeed.ToString("F1");
        }
        else if (option == 1)
        {
            if (GameSettings.NoteOffset >= 0) textComponent.text = "Note Offset +" + GameSettings.NoteOffset.ToString() + "ms";
            else textComponent.text = "Note Offset " + GameSettings.NoteOffset.ToString() + "ms";

        }
        else if (option == 2)
        {
            textComponent.text = gameModes[GameSettings.GameMode];
        }
    }
}
