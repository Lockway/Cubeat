using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private bool soundPlayed;
    private int keyPressed;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        keyPressed = 0;
        audioSource = GetComponent<AudioSource>();
        transform.localPosition = new Vector3(-2500, 0, -8000f);
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

            if (keyPressed >= 3 && transform.localPosition.x < 900f)
            {
                if (!soundPlayed)
                {
                    audioSource.Play();
                    soundPlayed = true;
                }

                transform.localPosition += new Vector3(Time.deltaTime * 3000f, 0, 0);
            }

            if (transform.localPosition.x > 900f)
            {
                SceneManager.LoadScene("Selection");
            }
        }
    }
}
