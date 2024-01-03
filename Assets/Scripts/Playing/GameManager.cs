using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource theMusic;

    public int currentScore;
    public int currentCombo;
    public int maxCombo;
    public int judgeLevel;
    // Perfect=2, Great=1, Miss=0

    public List<int> judges;

    public bool startPlaying;
    public bool startSong;
    public bool playingEnd;
    public float delayTime;

    void Awake()
    {
        currentScore = 0; currentCombo = 0;
        judges = new List<int> { 0, 0, 0, 0 };

        instance = this;

        theMusic = GetComponent<AudioSource>();
        theMusic.clip = GameSettings.SelectedSong;

        theMusic.time = 0;
        delayTime = 0;

        // ------------------------------------
        GameSettings.HighSpeed = 8.7f;
        GameSettings.SongOffset = 0f;
        // Only for test, need revision later

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
        else if (!theMusic.isPlaying)
        {
            playingEnd = true;
        }
    }

    public void NoteHit()
    {
        if (currentScore == 0) currentScore += 1000000 % (maxCombo * 2);

        int OneNoteScore = 1000000 / (maxCombo * 2);
        currentScore += OneNoteScore * judgeLevel;

        GameManager.instance.currentCombo++;
    }

    public void NoteMiss()
    {
        GameManager.instance.currentCombo = 0;
    }
}
