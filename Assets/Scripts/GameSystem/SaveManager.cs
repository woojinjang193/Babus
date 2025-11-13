using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    private const string Key = "UserData";

    public static UserData Load()
    {
        var json = PlayerPrefs.GetString(Key, ""); // ""´Â ¹¹ÀÓ ?
        if(string.IsNullOrEmpty(json))
        {
            return null;
        }

        return JsonUtility.FromJson<UserData>(json);
    }
    public static void Save(UserData data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(Key, json);
        PlayerPrefs.Save();
    }
}
