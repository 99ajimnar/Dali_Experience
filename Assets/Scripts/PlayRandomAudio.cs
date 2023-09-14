using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClipsList;
    private AudioSource audioSource;
    [SerializeField] private float delayBetweenAudio = 180.0f; //seconds
    private int currentClipIndex = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlayFirstAudio", delayBetweenAudio);
    }

    private void PlayFirstAudio()
    {
        if (currentClipIndex < audioClipsList.Length)
        {
            audioSource.clip = audioClipsList[currentClipIndex];
            audioSource.Play();
            currentClipIndex++;

            Invoke("PlayNextAudio", delayBetweenAudio);
        }
    }
    private void PlayNextAudio()
    {
        if (currentClipIndex < audioClipsList.Length)
        {
            audioSource.clip = audioClipsList[currentClipIndex];
            audioSource.Play();
            currentClipIndex++;

            Invoke("PlayNextAudio", delayBetweenAudio);
        }
    }
}





