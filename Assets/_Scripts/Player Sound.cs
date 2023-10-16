using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{

    private AudioSource _audioSource;

    public AudioClip _clipPowerUp;
    public AudioClip _clipMonster;
    public AudioClip _clipDie;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayCollectPowerUp() { PlayClip(_clipPowerUp); }
    public void PlayCollectHitMonster() { PlayClip(_clipMonster);}
    public void PlayCollectDie() { PlayClip(_clipDie); }
    private void PlayClip(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
