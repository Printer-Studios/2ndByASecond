using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static AudioManager instance { get; private set; }

    private List<EventInstance> eventInstances;
    private EventInstance musicMenuEventInstance;
    private EventInstance backgroundNoiseEventInstance;


    public void Awake()
    {
        if (instance == null)
        {
            Debug.LogError("Found more than one AudioManager in the scene.");
        }
        instance = this;
    }
    public void StartBackground()
    {
        InitializeBackground(FMODEvents.instance.BackGroundCarretera);
    }

    private void InitializeBackground(EventReference background)
    {
        backgroundNoiseEventInstance = RuntimeManager.CreateInstance(background);
        backgroundNoiseEventInstance.start();
    }

    public void StopBackground()
    {
        backgroundNoiseEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        backgroundNoiseEventInstance.release();
    }

    private void InitializeMusic (EventReference music)
    {
        musicMenuEventInstance = RuntimeManager.CreateInstance(music);
        musicMenuEventInstance.start();
        
    }

    public void StartMusic(string name)
    {
        name = name.ToLower();
        if (name == "menu")
        {
            InitializeMusic(FMODEvents.instance.MusicaMenu);
        }
        else if (name == "carrera")
        {
            InitializeMusic(FMODEvents.instance.MusicaCarrera);
        }
        else if (name == "victoria")
        {
            InitializeMusic(FMODEvents.instance.MusicaVictoria);
        }
        else if (name == "derrota")
        {
            InitializeMusic(FMODEvents.instance.MusicaDerrota);
        }
    }
    public void StopMusic()
    {
        musicMenuEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        musicMenuEventInstance.release();
    }


    public void PlayerOneShot (EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}
