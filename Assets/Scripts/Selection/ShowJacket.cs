using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowJacket : MonoBehaviour
{
    private Image displayImage;

    // Start is called before the first frame update
    void Start()
    {
        displayImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        displayImage.sprite = GameSettings.imageArray[GameSettings.CurrentSong];

        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Return))
        {
            GameSettings.SelectedJacket = displayImage.sprite;
        }
    }
}
