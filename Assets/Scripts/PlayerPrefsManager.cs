using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {
    const string MASTER_KEY_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    #region Volume

    public static void SetMasterVolume(float volume)
    {
        if (volume <= 0f || volume >= 1)
        {
            Debug.Log("Master volume out of range");
            return;
        }

        PlayerPrefs.SetFloat(MASTER_KEY_VOLUME_KEY, volume);
    }

    public static float GetMasterVolume()
    {
        if (!PlayerPrefs.HasKey(MASTER_KEY_VOLUME_KEY))
        {
            return 0f;
        }

        return PlayerPrefs.GetFloat(MASTER_KEY_VOLUME_KEY);
    }

    #endregion

    #region UnlockLevel

    public static void UnlockLevel(int level)
    {
        if(!IsValidLevel(level))
        {
            Debug.Log("Invalid level");
            return;
        }

        PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
    }

    public static bool IsLevelUnlocked(int level)
    {
        if (!IsValidLevel(level))
        {
            Debug.Log("Invalid level");
            return false;
        }

        var key = LEVEL_KEY + level;
        if (!PlayerPrefs.HasKey(key))
        {
            return false;
        }

        return PlayerPrefs.GetInt(key) == 1f;
    }

    #endregion

    #region Difficulty

    public static void SetDifficulty(float difficulty)
    {
        if (!IsValidDifficulty(difficulty))
        {
            Debug.Log("Invalid difficulty");
            return;
        }

        PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
    }

    public static float GetDifficulty()
    {
        if (!PlayerPrefs.HasKey(DIFFICULTY_KEY))
        {
            return 0f;
        }

        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }

    #endregion

    private static bool IsValidLevel(int level)
    {
        if (level <= Application.levelCount - 1 && level >= 0)
        {
            return true;
        }

        return false;
    }

    private static bool IsValidDifficulty(float difficulty)
    {
        return difficulty >= 0f && difficulty <= 1f;
    }
}
