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

        //Invoke method after 3 mins every 3 mins
        //InvokeRepeating("PlayAudio", 180.0f, delayBetweenAudio);
        Invoke("PlayFirstAudio", delayBetweenAudio);
    }

    private void PlayAudio()
    {
        AudioClip randomClip = audioClipsList[Random.Range(0, audioClipsList.Length)];

        audioSource.clip = randomClip;
        audioSource.Play();
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





