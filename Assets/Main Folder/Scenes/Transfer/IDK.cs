using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDK : MonoBehaviour
{
    public AudioSource music;

    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}
