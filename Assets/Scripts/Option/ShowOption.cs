using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowOption : MonoBehaviour
{
    public int option;
    private TextMeshProUGUI textComponent;
    private string[] gameModes = { "Normal Mode", "Mirror", "Lane Random", "Color Random", "Super Random" };

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
            textComponent.text = "High Speed\t" + GameSettings.HighSpeed.ToString("F1");
        }
        else if (option == 1)
        {
            textComponent.text = gameModes[GameSettings.GameMode];
        }
    }
}
