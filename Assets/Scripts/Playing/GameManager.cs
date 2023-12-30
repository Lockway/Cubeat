using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource theMusic;
    public bool startPlaying;
    public bool startSong;
    public float delayTime;

    public int hitTimes; // Only for test!!

    void Awake()
    {
        hitTimes = 0;

        instance = this;

        theMusic = GetComponent<AudioSource>();
        theMusic.clip = GameSettings.SelectedSong;

        theMusic.time = 0;
        delayTime = 0;

        // ------------------------------------
        GameSettings.HighSpeed = 8.7f;
        GameSettings.SongOffset = 0.5f;
        // Need revision after making 'option'

        if (GameSettings.SongOffset < 0.0f)
        {
            theMusic.time = -GameSettings.SongOffset;
        }
        else
        {
            delayTime = GameSettings.SongOffset;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
            }
        }
        else if (delayTime > 0.0f)
        {
            delayTime -= Time.deltaTime;
        }
        else if(!startSong)
        {
            theMusic.Play();
            startSong = true;
        }
    }

    public void NoteHit()
    {
        hitTimes++;
        Debug.Log("Note hit #" + hitTimes);
    }

    public void NoteMiss()
    {

    }
}
