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
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
