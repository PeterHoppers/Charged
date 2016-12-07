using UnityEngine;
using System.Collections;

public class SoundEffectsManager : MonoBehaviour
{
    public int soundInterval;
    public AudioClip[] soundEffects;

    private AudioSource source;
    private float timer;

    void Start()
    {
       source =  GetComponent<AudioSource>();
    }

    void Update()
    {
        if(!source.isPlaying && (int)Time.time % soundInterval == 0 && (int)Time.time != 0)
        {
            source.clip = soundEffects[Random.Range(0, soundEffects.Length)];                   // If it is not playing a song already, play a random one.
            source.Play();
        }
    }
}
