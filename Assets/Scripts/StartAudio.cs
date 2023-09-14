using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioSource audioSourceGala;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("PlayAudio");
            StartCoroutine(GalaTalkingCoroutine());
            //if (!audioSource.isPlaying)
            //{
            //    audioSource.Play();
            //}
        }
    }
    private IEnumerator GalaTalkingCoroutine()
    {
        Debug.Log("Coroutine");
        audioSourceGala.Play();
        yield return new WaitForSeconds(audioSourceGala.clip.length + 2);
        audioSource.Play();

    }
}
