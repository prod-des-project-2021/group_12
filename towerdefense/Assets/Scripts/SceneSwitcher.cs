using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher switcherInstance;
   private int levelToLoad;
   public bool fadeToNextLevelStarted = false;
 public Animator animator;
    // Start is called before the first frame update
   private void Start() {
   switcherInstance = this;    
   }
 public void fadeToLevel (int levelIndex)
    {
         levelToLoad = levelIndex;
         animator.SetTrigger("fadeOut");
         fadeToNextLevelStarted = true;
       
    }

    //helpot siirtymät tasolta toiselle
    public void fadeToNextLevel()
    {
        fadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        fadeToNextLevelStarted = false;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
