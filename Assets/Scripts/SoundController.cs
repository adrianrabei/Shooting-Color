using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip pop;
    private AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("music", 1) == 1)
        {
            PlaySound(name);
        }
    }



    public void PlaySound(string name)
    {
        if (PlayerPrefs.GetInt("music", 1) == 0)
        {
            return;
        }
        if (name == "pop")
        {
            aSource.PlayOneShot(pop);
        }
    }
}
