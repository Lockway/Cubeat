using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource theMusic;
    public Queue<GameObject>[] notesInLane;

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
        instance = this;

        currentScore = 0; currentCombo = 0;
        judges = new List<int> { 0, 0, 0, 0 };
        
        notesInLane = new Queue<GameObject>[9];
        for (int i = 0; i < 9; i++)
        {
            notesInLane[i] = new Queue<GameObject>();
        }

        theMusic = GetComponent<AudioSource>();
        theMusic.clip = GameSettings.SelectedSong;

        theMusic.time = 0;
        delayTime = 0.0f;

        // ------------------------------------
        GameSettings.HighSpeed = 8.0f;
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
        } // Song Start
        else if (delayTime > 0.0f)
        {
            delayTime -= Time.deltaTime;
        } // Song offset
        else if(!startSong)
        {
            theMusic.Play();
            startSong = true;
        } // Song Play
        else if (!theMusic.isPlaying)
        {
            playingEnd = true;
        } // Song End
    }

    public void NoteHit(int k)
    {
        if (currentScore == 0) currentScore += 1000000 % (maxCombo * 2);

        int OneNoteScore = 1000000 / (maxCombo * 2);
        currentScore += OneNoteScore * judgeLevel;

        currentCombo++;
        notesInLane[k].Dequeue();
    }

    public void NoteMiss(int k)
    {
        currentCombo = 0;
        notesInLane[k].Dequeue();
    }
}
