using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public Slider volume;
   




    void Start()
    {
       
        volume.value = PlayerPrefs.GetFloat("MusicVolume");
        
        
    }

    
    void Update()
    {
        music.volume = volume.value;
    }

    public void VolumePrefs() {

        PlayerPrefs.SetFloat("MusicVolume", music.volume);
        
    }

    void PlayMusic() {

        StartCoroutine("FadeSound");

    }

    IEnumerator FadeSound()
    {

        while(music.volume > 0.01f)
        {

            music.volume -= Time.deltaTime / 1.0f;
            yield return null;
        
        }
    
    
    }




}
