using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameSettings
{
    public static AudioClip SelectedSong { get; set; }
    public static int CurrentSong { get; set; }
    public static float HighSpeed { get; set; }
    public static float SongOffset { get; set; }

    public static class JudgeTiming
    {
        public static int Perfect = 50;
        public static int Good = 150;
    }
    public static Sprite SelectedJacket { get; set; }
    public static List<List<int>> NoteScore { get; set; }

    public static string[] songTitles = { "666", "Arghena", "Chronomia", "Kart Rider", "XENOViA" };
    public static float[] songPreview = { 12.3f, 110.5f, 69.8f, 1.5f, 70.5f };
}
