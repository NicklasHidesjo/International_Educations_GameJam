using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] startMusic;
    [SerializeField] private AudioClip[] attackingSounds;
    [SerializeField] private AudioClip[] zombieDetection;
    public AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        PlayMusic(0, 0.01f);
    }

    public AudioClip PlayMusic(int i, float a)
    {
        AudioClip audioClip = startMusic[i];
        source.PlayOneShot(startMusic[i], a);
        return audioClip;
    }

    public void AttackingSounds()
    {
        source.clip = attackingSounds[Random.Range(0, attackingSounds.Length)];

        if (!source.isPlaying)
        {
            source.Play();
        }
    }

    public AudioClip ZombieDetectingSound()
    {
        AudioClip audioClip = zombieDetection[Random.Range(0, zombieDetection.Length)];

        return audioClip;
    }
}
