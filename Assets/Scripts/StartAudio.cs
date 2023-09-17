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
        }
    }
    private IEnumerator GalaTalkingCoroutine()
    {
        Debug.Log("Coroutine");
        audioSourceGala.Play();
        yield return new WaitForSeconds(audioSourceGala.clip.length + 2);
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length + 2);
        if (this != null)
        {
            this.gameObject.SetActive(false);
        }        
    }
}
