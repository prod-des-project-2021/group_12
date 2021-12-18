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
	public AudioSource buildingSound;
    public AudioSource sellingSound;
    public AudioSource mainMenuBackgroundMusic;
    public AudioSource firstmapBackgroundMusic;


    public void playTankFireSound()
    {
        if (tankFireSound != null) tankFireSound.Play();
    }
    public void playMissileFireSound()
    {
        if (missileFireSound != null) missileFireSound.Play();
    }
    public void playMissileExplosionSound(){
        if (missileHitSound != null) missileHitSound.Play();
    }
    public void playMinigunSpinSound(){
        if (minigunSpinSound != null) minigunSpinSound.Play();
    }
    public void playMinigunFireSound()
    {
        if (minigunFireSound != null) minigunFireSound.Play();
    }
    public void playSniperFireSound()
    {
        if (sniperFireSound != null) sniperFireSound.Play();
    }
    public void playZapTowerFireSound()
    {
        if (zapTowerSound != null) zapTowerSound.Play();
    }
    public void playEnemyDeathSound()
    {
        if(enemyDeathSound != null) enemyDeathSound.Play();

    }
	public void playBuildingSound()
    {
        if(buildingSound != null) buildingSound.Play();
    }

	public void playSellingSound()
    {
        if(sellingSound != null) sellingSound.Play();
    }
    int count = 0;
    IEnumerator fadeInMainmenuMusic;
    private void Start() {

     soundInstance = this;
    }

    

    public static IEnumerator fadeOut ( AudioSource audioSource, float fadeTime) {
        {
            float startVolume = audioSource.volume;
            Debug.Log("vola " +audioSource.volume);
            while (audioSource.volume > 0){
                audioSource.volume -= startVolume * Time.deltaTime /fadeTime;
                 Debug.Log("vola2 " +audioSource.volume);
                yield return null;
            }
            audioSource.Stop();
            audioSource.volume = startVolume;
        }
    }
    public static IEnumerator fadeIn ( AudioSource audioSource, float fadeTime) {
        {
            audioSource.Play();
        
            float startVolume = audioSource.volume;
            while (audioSource.volume < 1){
            
                audioSource.volume += startVolume + Time.deltaTime /fadeTime;
            
                yield return null;
            }
        
           // audioSource.volume = startVolume;
        }
    }
     private void Update() 
        {
            if(SceneManager.GetActiveScene().name == "MainMenu"){
           
            if(!mainMenuBackgroundMusic.isPlaying){
               fadeInMainmenuMusic = fadeIn(mainMenuBackgroundMusic, 3f);
               StartCoroutine(fadeInMainmenuMusic);
            }
            if(SceneSwitcher.switcherInstance.fadeToNextLevelStarted && count == 0)
			{
				StopCoroutine(fadeInMainmenuMusic);
				IEnumerator fadeOutMainmenuMusic = fadeOut(mainMenuBackgroundMusic, 1f);
				StartCoroutine(fadeOutMainmenuMusic);
				 count++;
			}
           
            }
        
            if(SceneManager.GetActiveScene().name == "FirstMap"){

                if(!firstmapBackgroundMusic.isPlaying)
                {  
					IEnumerator fadeInFirstMapMusic = fadeIn(firstmapBackgroundMusic, 3f);
					StartCoroutine(fadeInFirstMapMusic);
                }
			}
		}

}
