using UnityEngine;

public class SetStartVolume : MonoBehaviour {

    private MusicManager musicManager;

    // Use this for initialization
    void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();

        if (!musicManager)
        {
            Debug.LogWarning("No music manager found in start scene, can't set volume.");
            return;
        }

        Debug.Log("Found persistent music manager: " + musicManager);
        musicManager.SetVolume(PlayerPrefsManager.GetMasterVolume());
    }
}
