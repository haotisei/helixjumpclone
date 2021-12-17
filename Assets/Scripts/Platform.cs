using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    public AudioSource Sound;

    private void Start()
    {
        Sound = Instantiate(Sound);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.CurrentPlatform = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        
        Sound.Play();
        gameObject.SetActive(false);
        
        DestroyedPlatform.Instance.Score(1);
    }
}
