﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioCategory playerHurtSounds;
    public AudioCategory meteorCollideSounds;
    


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}

[System.Serializable]
public class AudioCategory
{
    public AudioSource sound;
    public AudioClip[] sounds;


    public void PlayRandom()
    {
        int i = Random.Range(0, sounds.Length);

        sound.clip = sounds[i];
        sound.Play();


    }


}

