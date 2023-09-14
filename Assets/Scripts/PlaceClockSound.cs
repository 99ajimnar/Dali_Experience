using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaceClockSound : MonoBehaviour
{
    [SerializeField] GameObject correctClock;
    
    [SerializeField] AudioClip incorrectClip;
    [SerializeField] AudioClip correctClip;

    private Collider socketCollider;
    private AudioSource audioSource;

    private void Start()
    {
        socketCollider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
        GetComponent<XRSocketInteractor>().selectEntered.AddListener(OnSelectEntered);
    }
    public void PlaySound()
    {
        if (socketCollider.bounds.Contains(correctClock.transform.position))
        {
            audioSource.clip = correctClip;
            Debug.Log(correctClip.name);
            audioSource.Play();
        }
        else
        {
            audioSource.clip = incorrectClip;
            Debug.Log(incorrectClip.name);
            audioSource.Play();
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        PlaySound();
    }
}
