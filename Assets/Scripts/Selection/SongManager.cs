using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongManager : MonoBehaviour
{
    public AudioClip[] songs;
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
        player.clip = songs[i];
        player.time = GameSettings.songPreview[i];
        player.Play();
    }


    // Start is called before the first frame update
    void Start()
    {
        GameSettings.CurrentSong = 0;
        n = songs.Length;

        player = GetComponent<AudioSource>();
        player.playOnAwake = false;
        PlaySong();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            player.Stop();

            GameSettings.CurrentSong++;
            GameSettings.CurrentSong %= n;

            PlaySong();
        }

        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            player.Stop();

            GameSettings.CurrentSong += (n - 1);
            GameSettings.CurrentSong %= n;

            PlaySong();
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            player.Stop();
            OnSongSelected(songs[GameSettings.CurrentSong]);
        }
    }
}
