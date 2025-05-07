using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] clips;

    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }
    public void PlayClip(int clipIndex)
    {
        if (clipIndex < 0 || clipIndex >= clips.Length)
            return;
        audioSource.clip = clips[clipIndex];
        audioSource.Play();
    }
}
