using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioSource defaultAudioSource;
    [SerializeField] private AudioSource bossAudioSource;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip reloadClip;
    [SerializeField] private AudioClip energyClip;

    public void PlayShootSound()
    {
        effectAudioSource.PlayOneShot(shootClip);
    }
    public void PlayReloadSound()
    {
        effectAudioSource.PlayOneShot(reloadClip);
    }
    public void PlayEnergySound()
    {
        effectAudioSource.PlayOneShot(energyClip);
    }
    public void PlayDefaultAudioSoure()
    {
        bossAudioSource.Stop();
        defaultAudioSource.Play();
    }
    public void PlayBossAudioSource()
    {
        defaultAudioSource.Stop();
        bossAudioSource.Play();
    }
    public void StopAudioGame()
    {
        defaultAudioSource.Stop();
        bossAudioSource.Stop();
        effectAudioSource.Stop();
    }
}
