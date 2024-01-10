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

    void Start()
    {
        GameSettings.CurrentSong = 0;
        if (GameSettings.HighSpeed < 1.0f) GameSettings.HighSpeed = 7.0f;

        if (!GameSettings.Init)
        {
            GameSettings.songTitles = new List<string>();
            GameSettings.songLevels = new List<string>();
            GameSettings.songPreview = new List<float>();
            GameSettings.imageArray = new List<Sprite>();
            GameSettings.songClips = new List<AudioClip>();

            findSongs(); // Titles

            foreach (string title in GameSettings.songTitles)
            {
                string filepath = Path.Combine(Application.dataPath, "Resources/Songs", title, "info.txt");
                List<string> lines = new List<string>();
                lines.AddRange(File.ReadAllLines(filepath));

                GameSettings.songLevels.Add(lines[1]);
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
