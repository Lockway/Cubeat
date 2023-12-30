using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowJacket : MonoBehaviour
{
    public Sprite[] imageArray;
    private Image displayImage;

    // Start is called before the first frame update
    void Start()
    {
        displayImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (imageArray.Length > 0)
        {
            displayImage.sprite = imageArray[GameSettings.CurrentSong];
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            GameSettings.SelectedJacket = displayImage.sprite;
        }
    }
}
