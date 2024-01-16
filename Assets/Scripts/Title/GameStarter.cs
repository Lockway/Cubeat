using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class NewBehaviourScript : MonoBehaviour
{
    public string sceneNameToLoad;
    private int[] tenPow = { 1, 10, 100 };
    private string[] levelName = { "Easy.txt", "Normal.txt", "Hard.txt" };

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
                string filepath = Path.Combine(Application.dataPath, "Resources/Songs", title, "info.txt");
                List<string> lines = new List<string>();
                lines.AddRange(File.ReadAllLines(filepath));
                // Reading Info.txt

                int levelVal = 0;
                string[] levelInfo = lines[1].Split(new char[] { ':' });

                for(int i = 0; i < 3; i++)
                {
                    filepath = Path.Combine(Application.dataPath, "Resources/Songs", title, levelName[i]);
                    if (!File.Exists(filepath)) continue;

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
        string[] audioGUIDs = AssetDatabase.FindAssets("t:AudioClip", new[] { "Assets/Resources/Songs" });

        foreach (string guid in audioGUIDs)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            string fileName = Path.GetFileNameWithoutExtension(assetPath);
            GameSettings.songTitles.Add(fileName);
        }
    }
}
