using UnityEngine;
public class BuffScript : MonoBehaviour
{
    public float buffTowerRange = 50f;
    public float damageBuffPercent = 1.1f;
    public float rangeBuffPercent = 1.1f;
    public int buffLvl = 1;

    Collider[] exColliders;
    int collidersLenght;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, buffTowerRange);
    }

    void Update()
    {
        
        exColliders = Physics.OverlapSphere(transform.position, buffTowerRange);
        if (exColliders.Length > collidersLenght)
        {
            BuffTowers(exColliders.Length-1);
        }
    }
    void BuffTowers(int lenght)
    {
        exColliders = Physics.OverlapSphere(transform.position, buffTowerRange);
        collidersLenght = exColliders.Length;
        for (int i = lenght; i < exColliders.Length; i++)
        {
            
            if (exColliders[i].name.Contains("Minigun(Clone)"))
            {
                exColliders[i].gameObject.GetComponent<attackEnemy>().damage *= damageBuffPercent;
                exColliders[i].gameObject.GetComponent<attackEnemy>().attackRange *= rangeBuffPercent;

            }
            if (exColliders[i].name.Contains("Tank(Clone)"))
            {
                exColliders[i].gameObject.GetComponent<attackEnemy>().damage *= damageBuffPercent;
                exColliders[i].gameObject.GetComponent<attackEnemy>().attackRange *= rangeBuffPercent;
            }
            if (exColliders[i].name.Contains("MissileLauncher(Clone)"))
            {
                exColliders[i].gameObject.GetComponent<attackEnemy>().damage *= damageBuffPercent;
                exColliders[i].gameObject.GetComponent<attackEnemy>().attackRange *= rangeBuffPercent;
            }
            if (exColliders[i].name.Contains("ZapTower(Clone)"))
            {
                exColliders[i].gameObject.GetComponent<attackEnemy>().damage *= damageBuffPercent;
            }
        }


    }

    void Awake()
    {
        BuffTowers(0);
    }

}
