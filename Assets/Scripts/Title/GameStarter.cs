using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class NewBehaviourScript : MonoBehaviour
{
    public string sceneNameToLoad;
    private int[] tenPow = { 1, 10, 100 };
    private string[] levelName = { "Easy", "Normal", "Hard" };

    void Start()
    {
        GameSettings.CurrentSong = 0;
        GameSettings.NoteOffset = int.Parse(PlayerPrefsManager.LoadSettings("noteOffset") != "" ? PlayerPrefsManager.LoadSettings("noteOffset") : "0");
        GameSettings.HighSpeed = float.Parse(PlayerPrefsManager.LoadSettings("highSpeed") != "" ? PlayerPrefsManager.LoadSettings("highSpeed") : "5.0");

        if (!GameSettings.Init)
        {
            GameSettings.songTitles = new List<string>();
            GameSettings.songLevels = new List<int>();
            GameSettings.songPreview = new List<float>();
            GameSettings.imageArray = new List<Sprite>();
            GameSettings.songClips = new List<AudioClip>();

            findSongs(); // Titles

            foreach (string title in GameSettings.songTitles)
            {
                TextAsset textAsset = Resources.Load<TextAsset>("Songs/" + title + "/info");
                string[] lines = textAsset.text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                // Reading Info.txt

                int levelVal = 0;
                string[] levelInfo = lines[1].Split(new char[] { ':' });

                for(int i = 0; i < 3; i++)
                {
                    textAsset = Resources.Load<TextAsset>("Songs/" + title + "/" + levelName[i]);
                    if (textAsset == null) continue;

                    levelVal += int.Parse(levelInfo[i + 1]) * tenPow[i];
                    // Easy 1 - Normal 10 - Hard 100
                }
                GameSettings.songLevels.Add(levelVal);
                // songLevels

                string[] parts = lines[2].Split(new char[] { ':' });
                GameSettings.songPreview.Add(float.Parse(parts[1]));
                // songPreview

                Sprite jacket = Resources.Load<Sprite>("Songs/" + title + "/" + title);
                GameSettings.imageArray.Add(jacket);
                // imageArray

                AudioClip song = Resources.Load<AudioClip>("Songs/" + title + "/" + title);
                GameSettings.songClips.Add(song);
                // songClips
            }

            GameSettings.Init = true;
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }

    void findSongs()
    {
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>("Songs");
        foreach (var clip in audioClips) GameSettings.songTitles.Add(clip.name);
    }
}
