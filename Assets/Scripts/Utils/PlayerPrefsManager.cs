using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public static void SaveSettings(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    public static string LoadSettings(string key)
    {
        return PlayerPrefs.GetString(key, "");
    }
}