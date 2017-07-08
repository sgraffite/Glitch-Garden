using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public List<string> musicCollectionKeys;
    public List<AudioClip> musicCollectionValues;

    private Dictionary<string, AudioClip> musicCollection;

    private AudioSource music;

    private string currentLevelName;

    private Action PlayMusic;

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        music = GetComponent<AudioSource>();
        InitMusicCollection();
    }

    private void InitMusicCollection()
    {
        if (musicCollectionKeys.Count != musicCollectionValues.Count)
        {
            throw new System.Exception("Music collection must have the same number of keys as values!");
        }

        musicCollection = new Dictionary<string, AudioClip>();
        for (int i = 0; i < musicCollectionKeys.Count; i++)
        {
            musicCollection[musicCollectionKeys[i]] = musicCollectionValues[i];
        }
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentLevelName = scene.name;
        Debug.Log("Music player: loaded level: " + currentLevelName);
        //Debug.Log(mode);
        
        QueueNewMusicByLevelName();
        PlayMusic();
    }

    private void QueueNewMusicByLevelName()
    {
        if (!musicCollection.ContainsKey(currentLevelName))
        {
            PlayMusic = DoNothing;
            Debug.Log("No music loaded for level: " + currentLevelName);
            return;
        }

        Debug.Log("Queued music: " + musicCollection[currentLevelName]);
        music.clip = musicCollection[currentLevelName];
        PlayMusic = PlayNewMusicClip;
    }

    private void PlayNewMusicClip()
    {
        music.Stop();
        music.loop = true;
        music.Play();
    }

    private void DoNothing(){}
}
