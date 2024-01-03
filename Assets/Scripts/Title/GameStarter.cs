using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public string sceneNameToLoad;

    void Start()
    {
        GameSettings.CurrentSong = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) ||
        Input.GetKeyDown(KeyCode.Keypad2) ||
        Input.GetKeyDown(KeyCode.Keypad3) ||
        Input.GetKeyDown(KeyCode.Keypad4) ||
        Input.GetKeyDown(KeyCode.Keypad5) ||
        Input.GetKeyDown(KeyCode.Keypad6) ||
        Input.GetKeyDown(KeyCode.Keypad7) ||
        Input.GetKeyDown(KeyCode.Keypad8) ||
        Input.GetKeyDown(KeyCode.Keypad9))
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
