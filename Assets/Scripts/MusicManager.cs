using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundTrack1;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(backgroundTrack1);
        AudioManager.Instance.FadeIn();
    }
}
