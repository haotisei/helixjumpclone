using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Game Game;
    public Text Text;
    public AudioSource bounce;


    public Platform CurrentPlatform;

  
    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
        
    }

    public void Die()
    {
        Game.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
       
    }

    public void ReachFinish()
    {
        Rigidbody.velocity = Vector3.zero;
        Text.text = PlayerPrefs.GetInt("PlayerScore").ToString();
        Game.OnPlayerReachedFinish();
    }


    private void OnCollisionEnter(Collision collision)
    {
        bounce.Play();
        Debug.Log("Played");
    }
}
