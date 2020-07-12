using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioCategory playerHurtSounds;
    public AudioCategory meteorCollideSounds;
    public AudioCategory coinSounds;


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

    public void playSequential(int id)
    {

        if (id < sounds.Length && id >= 0)
        {
            sound.clip = sounds[id];
            sound.Play();

        }



    }


}


