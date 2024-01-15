using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource theMusic;
    public Queue<GameObject>[] notesInLane;
    // Essential

    public GameObject NoteButton;
    public GameObject HitPrefab;
    // Hit effect

    public int currentScore;
    public int currentCombo;
    public int maxCombo;
    // Perfect=2, Great=1, Miss=0

    public List<int> judges;

    public bool startPlaying;
    public bool startSong;
    public bool songEnd;
    public bool playingEnd;
    
    public int[] subkeys = { 23, 2, 21, 18, 3, 5, 22, 4, 17 };

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
        else if(!startSong)
        {
            theMusic.Play();
            startSong = true;
        } // Song Play
        else if (!theMusic.isPlaying)
        {
            songEnd = true;
        } // Song End
    }

    public void NoteHit(int k, int judgeLevel)
    {
        if (currentScore == 0) currentScore += 1000000 % (maxCombo * 2);

        int OneNoteScore = 1000000 / (maxCombo * 2);
        currentScore += OneNoteScore * judgeLevel;

        currentCombo++;
        if (k >= 0)
        {
            notesInLane[k].Dequeue();
            HitEffect(k % 3);
        }
    }

    public void NoteMiss(int k)
    {
        currentCombo = 0;
        if (k >= 0)
        {
            notesInLane[k].Dequeue();
        }
    }

    public KeyCode mainToSubKey(int keyNum)
    {
        return KeyCode.A + subkeys[keyNum];
    }

    public void HitEffect(int lane)
    {
        GameObject HitEffect = Instantiate(HitPrefab, NoteButton.transform);
        HitEffect.transform.localPosition = new Vector3(140 * (lane - 1), 0, -8000);
        NoteEffect HitScript = HitEffect.AddComponent<NoteEffect>();
    }
}
