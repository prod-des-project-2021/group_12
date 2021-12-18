using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher switcherInstance;
    private int levelToLoad;
    [HideInInspector] public bool fadeToNextLevelStarted = false;
    public Animator animator;
    // Start is called before the first frame update
    private void Awake() 
    {
        switcherInstance = this; 
    }
      
   
    public void fadeToLevel (int levelIndex)
    {
         fadeToNextLevelStarted = true;
         levelToLoad = levelIndex;
         if(animator != null && animator.isActiveAndEnabled)
         {
            
         animator.SetTrigger("fadeOut");
        
         }
       
    }

    //helpot siirtymät tasolta toiselle
    public void fadeToNextLevel()
    {
        fadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void onFadeComplete()
    {
        Debug.Log("fadecomplete");

        Debug.Log(levelToLoad);
        SceneManager.LoadScene(levelToLoad);
        fadeToNextLevelStarted = false;
        
    }
    public void QuitGame()
    {
         Time.timeScale = 1f;
        Application.Quit();
        Debug.Log("Quit");
    }
}
