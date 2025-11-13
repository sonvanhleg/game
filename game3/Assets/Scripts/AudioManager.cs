using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource effectSource;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip tapClip;
    [SerializeField] private AudioClip hurtClip;
    [SerializeField] private AudioClip crackEggClip;
    private bool hasPlayEffectSound = false;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public bool HasPlayEffectSound()
    {
        return hasPlayEffectSound;
    }
    public void SetHasPlayEffectSound(bool value)
    {
        hasPlayEffectSound=value;
    }
    // Start is called before the first frame update
    void Start()
    {
        effectSource.Stop();
        hasPlayEffectSound = true;
    }

    public void PlayJumClip()
    {
        effectSource.PlayOneShot(jumpClip);
    }
    public void PlayTapClip()
    {
        effectSource.PlayOneShot(tapClip);
    }
    public void PlayHurtClip()
    {
        effectSource.PlayOneShot(hurtClip);
    }
    public void PlayCrackEggClip()
    {
        effectSource.PlayOneShot(crackEggClip);
    }
}
