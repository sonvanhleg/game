using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundAudio;
    [SerializeField] private AudioSource effectAudio;

    [SerializeField] private AudioClip backGroundClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip coinClip;
    // Start is called before the first frame update
    void Start()
    {
        PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBackgroundMusic()
    {
        backgroundAudio.clip = backGroundClip;
        backgroundAudio.Play();
    }
    public void PlayCoinSound()
    {
        effectAudio.PlayOneShot(coinClip);
    }
    public void PlayJumpSound()
    {
        effectAudio.PlayOneShot(jumpClip);
    }
}
