using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int keyPressed;

    // Start is called before the first frame update
    void Start()
    {
        keyPressed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.playingEnd)
        {
            if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Return))
            {
                keyPressed++;
            }

            if (keyPressed >= 3)
            {
                SceneManager.LoadScene("Selection");
            }
        }
    }
}
