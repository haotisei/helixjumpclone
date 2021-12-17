using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolume : MonoBehaviour
{
    [Min(0)]
    public float volume;

    void Update()
    {
        AudioListener.volume = volume;
    }
}
