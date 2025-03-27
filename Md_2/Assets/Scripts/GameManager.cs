using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    [SerializeField] private TMP_Text playerName, playerHealth, enemyName, enemyHealth;
    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip loseSound;
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip buttonAttackSound;
    [SerializeField] private AudioClip buttonShieldSound;
    [SerializeField] private AudioClip healSound;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private Button healButton;
    private int mediumAttackCooldown = 0;

    private int enemyCounter = 1;
    private bool healUsed = false;

    void Start()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();

        RefreshUI();
    }
    
    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    private void PlayClickSound()
    {
        if (buttonClickSound != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(buttonClickSound);
        }
    }

    private void PlayAttackSound()
    {
        if (buttonAttackSound != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(buttonAttackSound);
        }
    }

    private void PlayShieldSound()
    {
        if (buttonShieldSound != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(buttonShieldSound);
        }
    }

    private void PlayHealSound()
    {
        if (healSound != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(healSound);
        }
    }

    public void AttackEnemy(int type)
    {
        if (type == 2 && mediumAttackCooldown > 0)
        {
            Debug.Log("u can not use Attack 2 now" + mediumAttackCooldown + " attack left");
            return;
        }

        int damage = 0;

        switch (type)
        {
            case 1:
                damage = player.ActiveWeapon.GetDamage(); 
                break;
            case 2:
                damage = Mathf.RoundToInt(player.ActiveWeapon.GetDamage() * 1.5f); 
                mediumAttackCooldown = 2; 
                break;
            case 3:
                damage = player.ActiveWeapon.GetDamage() * 2; 
                player.Health -= 2; 
                break;
        }

        PlayAttackSound();

        enemy.TakeDamage(damage);

        if (enemy.Health <= 0)
        {
            SpawnNewEnemy();
            return;
        }

        int enemyDamage = enemy.Attack();
        player.TakeDamage(enemyDamage);

        if (mediumAttackCooldown > 0)
        {
            mediumAttackCooldown--;
        }

        RefreshUI();
    }
    public void ToggleShield()
    {
        PlayShieldSound();
        player.ToggleShield();
        RefreshUI();
    }

    public void HealPlayer()
    {
        if (healUsed || player.Health <= 0) return;

        player.Health += 50;
        healUsed = true;
        healButton.interactable = false;

        PlayHealSound();
        RefreshUI();
    }

    private void RefreshUI()
    {
        playerName.text = player.CharName;
        enemyName.text = enemy.name;
        playerHealth.text = "Health: " + player.Health.ToString() + (player.hasShield ? " Shield " : "");
        enemyHealth.text = "Health: " + enemy.Health.ToString();
    }

    private void SpawnNewEnemy()
    {
        enemy = Instantiate(enemy);
        enemyCounter++;
        enemy.name = "Enemy " + enemyCounter;
        enemy.Health = 20;

        RefreshUI();
    }

    public void GameOver()
    {
        if (loseSound != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(loseSound);
        }

        if (audioSource != null)
        {
            audioSource.Stop();
        }

        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        PlayClickSound();

        Time.timeScale = 1;
        player.Health = 100;
        enemy.Health = 20;
        gameOverUI.SetActive(false);
        healUsed = false;
        healButton.interactable = true;

        if (audioSource != null && backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        }

        RefreshUI();
    }
}


