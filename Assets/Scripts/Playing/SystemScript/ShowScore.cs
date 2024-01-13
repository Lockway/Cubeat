using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowScore : MonoBehaviour
{
    int currentScore;
    bool bounce;
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
            if (currentScore != GameManager.instance.currentCombo)
            {
                currentScore = GameManager.instance.currentCombo;
                currentText.text = currentScore.ToString();

                gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                bounce = true;
            }

            if (bounce)
            {
                gameObject.transform.localScale += new Vector3(Time.deltaTime * 10f, Time.deltaTime * 10f, Time.deltaTime * 10f);
                if (gameObject.transform.localScale.x >= 1.0f) bounce = false;
            }
        }
    }
}
