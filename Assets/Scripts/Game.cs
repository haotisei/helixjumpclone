using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Control Control;
    private int savedscore;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState{get; private set;}
    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Control.enabled = false;
        PlayerPrefs.SetInt("Score", savedscore);
        Debug.Log("Game Over!");
        ReloadLevel();
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Control.enabled = false;
        LevelIndex++;
        savedscore = PlayerPrefs.GetInt("Score");
        Debug.Log("You won!");
        ReloadLevel();
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "LevelIndex";



    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SaveScore()
    {
       
    }
}
