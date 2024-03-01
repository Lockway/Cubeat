using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    public int option;


    // Start is called before the first frame update
    void Start()
    {
        option = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (option > 0)
            {
                option--;
                transform.localPosition += new Vector3(0, 150, 0);
            }
        }
        // Up
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (option < 3)
            {
                option++;
                transform.localPosition -= new Vector3(0, 150, 0);
            }
        }
        // Down
        if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefsManager.SaveSettings("highSpeed", GameSettings.HighSpeed.ToString());
            PlayerPrefsManager.SaveSettings("noteOffset", GameSettings.NoteOffset.ToString());
            SceneManager.LoadScene("Selection");
        }
        // ESC


        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (option == 0 && GameSettings.HighSpeed < 20.0f)
            {
                GameSettings.HighSpeed += 0.1f;
            }
            else if (option == 1 && GameSettings.NoteOffset < 1000)
            {
                GameSettings.NoteOffset += 10;
            }
            else if (option == 2)
            {
                GameSettings.GameMode = (GameSettings.GameMode + 1) % 6;
            }
        }
        // Right

        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (option == 0 && GameSettings.HighSpeed > 1.0f)
            {
                GameSettings.HighSpeed -= 0.1f;
            }
            else if (option == 1 && GameSettings.NoteOffset > -1000)
            {
                GameSettings.NoteOffset -= 10;
            }
            else if (option == 2)
            {
                GameSettings.GameMode = (GameSettings.GameMode + 5) % 6;
            }
        }
        // Left

        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Return))
        {
            if (option == 3)
            {
                GameSettings.HighSpeed = 10.0f;
                GameSettings.NoteOffset = 0;
                GameSettings.GameMode = 0;
            }
        }
    }
}
