using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowScore : MonoBehaviour
{
    int currentScore;
    public int option;
    private TextMeshProUGUI currentText;


    // Start is called before the first frame update
    void Start()
    {
        currentText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (option == 0)
        {
            currentScore = GameManager.instance.currentScore;
            currentText.text = currentScore.ToString("D7");
        }
        else
        {
            currentScore = GameManager.instance.currentCombo;
            currentText.text = currentScore.ToString();
        }
    }
}
