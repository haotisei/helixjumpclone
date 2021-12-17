using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip Audioclip;

    [Min(0)]
    public float delay;

    [Min(0)]
    public float volume;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        _audio.PlayDelayed(delay);
    }

    private void OnDisable()
    {
        _audio.Stop();   
    }
}
