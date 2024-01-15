using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    AudioSource selectAudio;

    // Start is called before the first frame update
    void Start()
    {
        selectAudio = gameObject.GetComponent<AudioSource>();
        gameObject.transform.localPosition = new Vector3(180 * (GameSettings.Difficulty - 1), -23, -5000);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad4)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (GameSettings.Difficulty > 0)
            {
                selectAudio.Play();
                GameSettings.Difficulty--;
                gameObject.transform.localPosition -= new Vector3(180, 0, 0);
            }
        }
        // Left

        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (GameSettings.Difficulty < 2)
            {
                selectAudio.Play();
                GameSettings.Difficulty++;
                gameObject.transform.localPosition += new Vector3(180, 0, 0);
            }
        }
        // Right
    }
}
