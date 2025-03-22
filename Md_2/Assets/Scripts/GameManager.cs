using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    [SerializeField] private TMP_Text playerName, playerHealth, enemyName, enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    public void DoRound()
    {
        //int playerDamage = player.Attack();
        //enemy.TakeDamage(playerDamage);
        //Debug.Log("player name: " + player.CharName);
        enemy.TakeDamage(player.ActiveWeapon);
        int enemyDamage = enemy.Attack();
        player.TakeDamage(enemy.ActiveWeapon);
        RefreshUI();
    }

    private void RefreshUI()
    {
        playerName.text = player.CharName;
        enemyName.text = enemy.name;
        playerHealth.text =  "Health: " + player.health.ToString();   
        enemyHealth.text = "Health: " + enemy.health.ToString();
    }


}
