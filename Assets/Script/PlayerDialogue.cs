using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerDialogue : MonoBehaviour
{
    public AudioClip dialogueClip; // Aquí debes asignar el audio que quieres reproducir
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("PlayDialogue", 5f, 5f); // Reproducir el sonido cada 5 segundos
    }

    private void PlayDialogue()
    {
        audioSource.PlayOneShot(dialogueClip);
    }
}
