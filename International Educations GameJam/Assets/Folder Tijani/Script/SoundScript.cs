using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] startMusic;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        playMusic(0);
    }


    public void playMusic(int i)
    {
        source.clip = startMusic[i];

        if (!source.isPlaying)
        {
            source.Play();
        }
    }
}
