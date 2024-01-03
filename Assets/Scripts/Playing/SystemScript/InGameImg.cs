using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameImg : MonoBehaviour
{
    private Image displayImage;

    // Start is called before the first frame update
    void Start()
    {
        displayImage = GetComponent<Image>();
        displayImage.sprite = GameSettings.SelectedJacket;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
