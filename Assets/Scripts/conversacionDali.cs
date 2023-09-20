using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class conversacionDali : MonoBehaviour
{
    public AudioClip[] audioClips;
    private int currentClipIndex = 8;
    private AudioSource audioSource;
    private bool isPlaying = false;
    [SerializeField] TextMeshProUGUI textDisplay;
    public TextMeshProUGUI[] textos;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPlaying)
        {
            PlayNextClip();
           
        }
    }

    private void PlayNextClip()
    {
        if (currentClipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
            

            // Cambiar el texto del objeto de TextMeshPro para mostrar el texto asociado al clip actual
            textDisplay.text = textos[currentClipIndex].text;
            currentClipIndex++;
            isPlaying = true;
        }
        else
        {
            Debug.Log("All audio clips have been played.");

            
            SceneManager.LoadScene("InsideHead_Scene");
            

        }
    }

    private void Update()
    {
        if (!audioSource.isPlaying && isPlaying)
        {
            isPlaying = false;
            PlayNextClip(); // Reproducir el siguiente clip cuando el actual haya terminado.
        }
    }

    
    
}
