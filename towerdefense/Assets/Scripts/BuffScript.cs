using UnityEngine;
using System.Collections.Generic;
public class BuffScript : MonoBehaviour
{
    public float buffTowerRange = 50f;
    public float damageBuffPercent = 1.1f;
    public float rangeBuffPercent = 1.1f;

    Collider[] exColliders;
    List<GameObject> turretsInRange = new List<GameObject>();

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, buffTowerRange);
    }
    
    void Update()
    {
        exColliders = Physics.OverlapSphere(transform.position, buffTowerRange);
        for (int i = 0; i < exColliders.Length; i++)
        {
            if (exColliders[i].name == "Tank(Clone)" || 
                exColliders[i].name == "Minigun(Clone)" || 
                exColliders[i].name == "MissileLauncher(Clone)" || 
                exColliders[i].name == "ZapTower(Clone)" ||
                exColliders[i].name == "megatank(Clone)" ||
                exColliders[i].name == "Mega Zap(Clone)" ||
                exColliders[i].name == "Mega Missile(Clone)" ||
                exColliders[i].name == "Mega Minigun(Clone)")
            {
                if (turretsInRange.Count == 0)
                {
                    turretsInRange.Add(exColliders[i].gameObject);
                    BuffTowers(exColliders[i].gameObject);
                }
                else
                {
                    if (!turretsInRange.Contains(exColliders[i].gameObject))
                    {
                        turretsInRange.Add(exColliders[i].gameObject);
                        BuffTowers(exColliders[i].gameObject);
                    }
                }
            }
        }
    }

    void BuffTowers(GameObject tower)
    {
        if (!tower.name.Contains("ZapTower(Clone)") || !tower.name.Contains("Mega Zap(Clone)"))
        {
            tower.GetComponent<attackEnemy>().damage *= damageBuffPercent;
            tower.GetComponent<attackEnemy>().attackRange *= rangeBuffPercent;
        }
        else
        {
            tower.GetComponent<attackEnemy>().damage *= damageBuffPercent;
        }
    }

}
