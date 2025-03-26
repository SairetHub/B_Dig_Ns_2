using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    [SerializeField] private TMP_Text playerName, playerHealth, enemyName, enemyHealth;
    [SerializeField] private GameObject gameOverUI;
    private int enemyCounter = 1;

    void Start()
    {
        RefreshUI();
    }

    public void DoRound()
    {
        if (player.health <= 0)
        {
            GameOver();
            return;
        }
        
        enemy.TakeDamage(player.ActiveWeapon.GetDamage());

        if (enemy.health <= 0)
        {
            SpawnNewEnemy();
            return;
        }

        int enemyDamage = enemy.Attack();
        player.TakeDamage(enemyDamage);
        RefreshUI();
    }

    public void ToggleShield()
    {
        player.ToggleShield();
        RefreshUI();
    }

    private void RefreshUI()
    {
        playerName.text = player.CharName;
        enemyName.text = enemy.name;
        playerHealth.text = "Health: " + player.health.ToString() + (player.hasShield ? " Shield " : "");
        enemyHealth.text = "Health: " + enemy.health.ToString();
    }

    private void SpawnNewEnemy()
    {

        enemy = Instantiate(enemy);
        enemyCounter++;
        enemy.name = "Enemy " + enemyCounter;
        enemy.health = 20;
        
        RefreshUI();
    }
    

    private void GameOver()
    {
        gameOverUI.SetActive(true); 
        Time.timeScale = 0; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        player.health = 100;
        enemy.health = 20;
        gameOverUI.SetActive(false);
        RefreshUI();
    }
}

