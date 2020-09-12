using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Static Instance
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if(instance == null)
                {
                    instance = new GameObject("Spawned AudioManager", typeof(AudioManager)).GetComponent<AudioManager>();
                }
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    #endregion

    #region Fields
    private AudioSource musicSource;

    private bool firstMusicSourcePlaying;
    #endregion

    private void Awake()
    {
        //Don't destroy
        DontDestroyOnLoad(this.gameObject);

        //Create audio sources
        musicSource = this.gameObject.AddComponent<AudioSource>();

        //Loop music
        musicSource.loop = true;
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.volume = 1f;
        musicSource.Play();
    }

    public void FadeIn(float transitionTime = 2)
    {
        StartCoroutine(FadeInRoutine(transitionTime));
    }

    public void FadeOut(float transitionTime = 2)
    {
        StartCoroutine(FadeOutRoutine(transitionTime));
    }

    public IEnumerator FadeInRoutine(float transitionTime)
    {
        float t = 0.0f;
        //Fade In
        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            musicSource.volume = (t / transitionTime);
            yield return null;
        }
    }

    public IEnumerator FadeOutRoutine(float transitionTime)
    {
        float t = 0.0f;
        //Fade Out
        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            musicSource.volume = (1 - (t / transitionTime));
            yield return null;
        }
    }
}
