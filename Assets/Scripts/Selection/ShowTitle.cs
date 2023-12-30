using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShowTitle : MonoBehaviour
{
    public int delta;
    public int id;
    private TextMeshProUGUI textComponent;


    public void ChangeButtonText(int pos)
    {
        id = pos + delta;
        id += (GameSettings.songTitles).Length;
        id %= (GameSettings.songTitles).Length;

        textComponent.text = GameSettings.songTitles[id];
    }


    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        ChangeButtonText(GameSettings.CurrentSong);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeButtonText(GameSettings.CurrentSong);
    }
}
