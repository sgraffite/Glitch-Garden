using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;

    private const float defaultVolume = .8f;
    private const int defaultDifficulty = 2;

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
        Debug.Log(PlayerPrefsManager.GetDifficulty());
    }
	
	// Update is called once per frame
	void Update () {
        musicManager.SetVolume(volumeSlider.value);
        SetDifficulty(Mathf.FloorToInt(difficultySlider.value));
    }

    private void SetDifficulty(int difficulty)
    {
        difficulty = Mathf.Clamp(difficulty, 1, 3);
        PlayerPrefsManager.SetDifficulty(difficulty);
        Debug.Log(PlayerPrefsManager.GetDifficulty());
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }

    public void SaveAndExit()
    {
        Debug.Log(volumeSlider.value);
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        levelManager.LoadLevel("01a Main Menu");
    }
}
