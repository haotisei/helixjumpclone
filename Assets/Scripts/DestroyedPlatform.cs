using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyedPlatform : MonoBehaviour
{
    public static DestroyedPlatform Instance { get; private set; }
    public Text Display;

    public int PlatformCount { get; private set; }

    private void Awake()
    {
        Instance = this;
        PlatformCount = PlayerPrefs.GetInt("Score");
        Display.text = PlatformCount.ToString();
    }

    public void Score(int amount)
    {
        PlatformCount+= amount;
        PlayerPrefs.SetInt("Score", PlatformCount);
        UpdateScoreDisplay();
      
    }


    public void UpdateScoreDisplay()
    {
        Display.text = PlatformCount.ToString();
    }


    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }

}
