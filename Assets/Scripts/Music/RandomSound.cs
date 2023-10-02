using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomSound()
    {
        int randomIndex = Random.Range(0, clips.Length);

        audioSource.clip = clips[randomIndex];
        audioSource.Play();
    }
}
