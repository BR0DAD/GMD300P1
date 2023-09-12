using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyManager : MonoBehaviour
{
    public static MyManager Instance;

    public int playerScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this) 
        {
            Debug.LogError("More than 1 instance of manager", this);
            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void AddScore(int ScoreToAdd)
    {
        playerScore += ScoreToAdd;
    }
    public void RemoveScore(int ScoreToRemove) 
    {
        playerScore -= ScoreToRemove;

        if(playerScore < 0)
        {
            playerScore = 0;
        }
    }

    public int GetScoreTotal()
    {
        return playerScore;
    }
}
