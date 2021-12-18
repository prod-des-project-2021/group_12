using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData
{
    public float map1Score, sampleScore, roundMapScore;
    public int map1Level, sampleLevel, roundMapLevel;

    public SaveData(GameEngine gameEngine)
    {

        if (SceneManager.GetActiveScene().name == "FirstMap")
        {
            map1Score = gameEngine.score;
            map1Level = gameEngine.level;
            sampleScore = gameEngine.sampleHighScore;
            sampleLevel = gameEngine.sampleHighLevel;
            roundMapScore = gameEngine.roundMapHighScore;
            roundMapLevel = gameEngine.roundMapHighLevel;

        }
        else if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            sampleScore = gameEngine.score;
            sampleLevel = gameEngine.level;
            map1Score = gameEngine.map1HighScore;
            map1Level = gameEngine.map1HighLevel;
            roundMapScore = gameEngine.roundMapHighScore;
            roundMapLevel = gameEngine.roundMapHighLevel;
        }
        else if(SceneManager.GetActiveScene().name == "RoundMap")
        {
            roundMapScore = gameEngine.score;
            roundMapLevel = gameEngine.level;
            map1Score = gameEngine.map1HighScore;
            map1Level = gameEngine.map1HighLevel;
            sampleScore = gameEngine.sampleHighScore;
            sampleLevel = gameEngine.sampleHighLevel;
        }
        
    }
}
