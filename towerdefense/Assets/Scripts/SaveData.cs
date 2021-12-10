using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData
{
    public float map1Score, sampleScore;
    public int map1Level, sampleLevel;

    public SaveData(GameEngine gameEngine)
    {

        if (SceneManager.GetActiveScene().name == "FirstMap")
        {
            map1Score = gameEngine.score;
            map1Level = gameEngine.level;
            sampleScore = gameEngine.sampleHighScore;
            sampleLevel = gameEngine.sampleHighLevel;
            Debug.Log("FirstMap saved!");
            
        }else if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            Debug.Log("SampleScore Saved!");
            map1Score = gameEngine.map1HighScore;
            map1Level = gameEngine.map1HighLevel;
            sampleScore = gameEngine.score;
            sampleLevel = gameEngine.level;
        }
        
    }
}
