using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localPosition = new Vector3(180 * (GameSettings.Difficulty - 1), -23, -5000);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad4)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (GameSettings.Difficulty > 0)
            {
                GameSettings.Difficulty--;
                gameObject.transform.localPosition -= new Vector3(180, 0, 0);
            }
        }
        // Left

        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (GameSettings.Difficulty < 2)
            {
                GameSettings.Difficulty++;
                gameObject.transform.localPosition += new Vector3(180, 0, 0);
            }
        }
        // Right

    }
}
