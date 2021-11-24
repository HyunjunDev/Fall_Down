using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource backmusic;
    GameObject BackgroundMusic;

    void Awake()
    {
        BackgroundMusic = GameObject.Find("Bgm");
        backmusic = BackgroundMusic.GetComponent<AudioSource>(); 
        if (backmusic.isPlaying) return; 
        else
        {
            backmusic.Play();
            DontDestroyOnLoad(BackgroundMusic); 
        }
    }
    public void SetBGMVolume(float volume)
    {
        backmusic.volume = volume;
    }
}
