using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
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

public void playBuildingSound()
    {
        buildingSound.Play();
    }

public void playSellingSound()
    {
        sellingSound.Play();
    }

}
