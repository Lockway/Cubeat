using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultInfo : MonoBehaviour
{
    public int option;
    public Image jacket;
    public TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.playingEnd)
        {
            resultShow();
        }
    }

    void resultShow()
    {
        if (option < 4)
        {
            int val = GameManager.instance.judges[option];
            textComponent = GetComponent<TextMeshProUGUI>();

            textComponent.text = val.ToString();
        }
        else if (option == 4)
        {
            textComponent = GetComponent<TextMeshProUGUI>();
            List<string> ranks = new List<string> { "COLOR", "SSS", "SS", "S", "A", "B", "C", "D", "E", "F" };
            List<int> values = new List<int> { 0, 20000, 50000, 100000, 150000, 200000, 300000, 400000, 500000, 1000000 };

            for (int i = 0; i < 10; i++)
            {
                int val = GameManager.instance.currentScore;
                if (1000000 - val <= values[i])
                {
                    textComponent.text = ranks[i];
                    break;
                }
            }
        }   // Rank
        else if (option == 5)
        {
            textComponent = GetComponent<TextMeshProUGUI>();
            textComponent.text = GameSettings.songTitles[GameSettings.CurrentSong];
        }   // Title
        else if (option == 6)
        {
            jacket = GetComponent<Image>();
            jacket.sprite = GameSettings.SelectedJacket;
        }   // Jacket
        else if (option == 7)
        {
            int val = GameManager.instance.currentScore;
            textComponent = GetComponent<TextMeshProUGUI>();

            textComponent.text = val.ToString("D7");
        }   // Score
        else if (option == 8)
        {
            transform.position = new Vector3(0f, 0f, 0f);
        }   // Result Parent
        else
        {
            gameObject.SetActive(false);
        }   // Note Buttons
    }
}
