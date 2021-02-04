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

    public AudioClip AttackingSounds(float a)
    {
        AudioClip audioClip = attackingSounds[Random.Range(0, attackingSounds.Length)];
        source.PlayOneShot(attackingSounds[Random.Range(0, attackingSounds.Length)], a);
        return audioClip;
    }

    public AudioClip ZombieDetectingSound(float a)
    {
        AudioClip audioClip = zombieDetection[Random.Range(0, zombieDetection.Length)];
        source.PlayOneShot(zombieDetection[Random.Range(0, zombieDetection.Length)], a);
        return audioClip;
    }
}
