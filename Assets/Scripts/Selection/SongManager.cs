using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongManager : MonoBehaviour
{
    public AudioSource player;
    int n;

    public void OnSongSelected(AudioClip selectedSong)
    {
        GameSettings.SelectedSong = selectedSong;
        SceneManager.LoadScene("Playing");
    }

    public void PlaySong()
    {
        int i = GameSettings.CurrentSong;
        player.clip = GameSettings.songClips[i];
        player.time = GameSettings.songPreview[i];
        player.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        n = GameSettings.songClips.Count;

        player = GetComponent<AudioSource>();
        player.playOnAwake = false;
        PlaySong();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.Stop();

            GameSettings.CurrentSong++;
            GameSettings.CurrentSong %= n;

            PlaySong();
        }
        // Down

        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.Stop();

            GameSettings.CurrentSong += (n - 1);
            GameSettings.CurrentSong %= n;

            PlaySong();
        }
        // Up

        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Return))
        {
            int level = GameSettings.songLevels[GameSettings.CurrentSong];
            level = levelParser(level, GameSettings.Difficulty);

            if (level != 0)
            {
                player.Stop();
                OnSongSelected(GameSettings.songClips[GameSettings.CurrentSong]);
            }
        }
        // Select

        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.X))
        {
            player.Stop();
            SceneManager.LoadScene("Option");
        }
        // Select

        if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Escape))
        {
            player.Stop();
            SceneManager.LoadScene("Title");
        }
        // Select
    }

    int levelParser(int level, int pos)
    {
        for (int i = 0; i < pos; i++) level /= 10;
        return level % 10;
    }
}
