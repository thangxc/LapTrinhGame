using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip backgroundMusic; // Reference to the AudioClip

    void Start()
    {
        // Assign the AudioClip to the AudioSource
        audioSource.clip = backgroundMusic;

        // Set to loop the music
        audioSource.loop = true;

        // Play the audio
        audioSource.Play();
    }
}

