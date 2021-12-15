using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class sounds : MonoBehaviour
{
    public static sounds soundInstance;
    public AudioSource tankFireSound;
    public AudioSource missileFireSound;
    public AudioSource missileHitSound;
    public AudioSource minigunFireSound;
    
    public AudioSource minigunSpinSound;
    
    public AudioSource sniperFireSound;
    public AudioSource zapTowerSound;

public AudioSource enemyDeathSound;

public AudioSource mainMenuBackgroundMusic;
public AudioSource firstmapBackgroundMusic;

SceneSwitcher switcher;
public void playTankFireSound()
{
tankFireSound.Play();
}
public void playMissileFireSound()
{
 missileFireSound.Play();
}
public void playMissileExplosionSound(){
    
    missileHitSound.Play();
}
public void playMinigunSpinSound(){
    minigunSpinSound.Play();
}
public void playMinigunFireSound()
{
     minigunFireSound.Play();
}
public void playSniperFireSound()
{
    sniperFireSound.Play();
}
public void playZapTowerFireSound()
{
    zapTowerSound.Play();
}
public void playEnemyDeathSound()
{
    enemyDeathSound.Play();
}
//IEnumerator fadeOutMainmenuMusic;
private void Start() {

 soundInstance = this;



}

    

public static IEnumerator fadeOut ( AudioSource audioSource, float fadeTime) {
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0){
            audioSource.volume -= startVolume * Time.deltaTime /fadeTime;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
public static IEnumerator fadeIn ( AudioSource audioSource, float fadeTime) {
    {
        audioSource.Play();
        Debug.Log("vola " +audioSource.volume);
        float startVolume = audioSource.volume;
        while (audioSource.volume < 1){
            
            audioSource.volume += startVolume + Time.deltaTime /fadeTime;
             Debug.Log("vola2 " +audioSource.volume);
            yield return null;
        }
        
       // audioSource.volume = startVolume;
    }
}
 private void Awake() 
    {
        if(SceneManager.GetActiveScene().name == "MainMenu"){
           
           IEnumerator fadeInMainmenuMusic = fadeIn(mainMenuBackgroundMusic, 3f);
           StartCoroutine(fadeInMainmenuMusic);
           if(SceneSwitcher.switcherInstance.fadeToNextLevelStarted)
    {
 IEnumerator fadeOutMainmenuMusic = fadeOut(mainMenuBackgroundMusic, 5f);
         StartCoroutine(fadeOutMainmenuMusic);
    }
        }
        
        if(SceneManager.GetActiveScene().name == "FirstMap"){
               
          
           
            IEnumerator fadeInFirstMapMusic = fadeIn(firstmapBackgroundMusic, 3f);
            Debug.Log("biisi "+ firstmapBackgroundMusic);
            StartCoroutine(fadeInFirstMapMusic);
            
            
        }

    }


}
