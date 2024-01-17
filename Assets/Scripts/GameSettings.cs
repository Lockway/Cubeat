using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameSettings
{
    public static bool Init { get; set; }
    public static int CurrentSong { get; set; }
    public static float HighSpeed { get; set; }
    public static int NoteOffset { get; set; }
    public static int GameMode { get; set; }
    public static int Difficulty { get; set; }
    public static int AudioLatency = 100;
    // Numbers

    public static class JudgeTiming
    {
        public static int Perfect = 50;
        public static int Good = 120;
        public static int Miss = 200;
    }
    // Judge Setting

    public static AudioClip SelectedSong { get; set; }
    public static Sprite SelectedJacket { get; set; }
    public static List<List<int>> NoteScore { get; set; }
    // Game Playing


    public static List<string> songTitles { get; set; }
    public static List<int> songLevels { get; set; }
    public static List<float> songPreview { get; set; }
    public static List<Sprite> imageArray { get; set; }
    public static List<AudioClip> songClips { get; set; }
    // Song Database
}
