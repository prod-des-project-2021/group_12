using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public int playerHealth = 100;
    public int money = 100;
    public static GameEngine gameInstance;
    // Start is called before the first frame update
    void Start()
    {
        gameInstance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damage)
    {
        playerHealth -= damage;
        Debug.Log("Player HP: " + playerHealth);
    }

    string SpendMoney(int amount)
    {
        if(money >= amount)
        {
            money -= amount;
            return money.ToString();
        }
        else
        {
            return "Not enough money :(";
        }
    }

    void AddMoney(int amount)
    {
        money += amount;
    }
}
