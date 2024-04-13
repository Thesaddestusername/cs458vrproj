using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip backgroundMusicClip;

    // Adjust the volume of the background music in the inspector
    [Range(0f, 1f)]
    public float volume = 0.5f;

    void Start()
    {
        // Add an AudioSource component to the game object
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = backgroundMusicClip;

        audioSource.volume = volume;

        audioSource.loop = true;

        audioSource.Play();
    }
}