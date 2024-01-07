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
        if (GameSettings.HighSpeed < 1.0f) GameSettings.HighSpeed = 5.0f;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
