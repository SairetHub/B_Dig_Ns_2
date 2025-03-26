using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int health;
    public bool hasShield = false;
    public int shieldDurability = 5;
    public int shieldDamageReduction = 50;
    private int shieldCooldown = 0; 
    [SerializeField] private Weapon activeWeapon;

  
    [SerializeField] private Button shieldButton; 

    public Weapon ActiveWeapon
    {
        get { return activeWeapon; }
    }

    public virtual int Attack()
    {
        
        if (shieldCooldown > 0)
        {
            shieldCooldown--;
        }
        return activeWeapon.GetDamage();
    }

    public void TakeDamage(int damage)
    {
        if (hasShield)
        {
            int reducedDamage = damage * (100 - shieldDamageReduction) / 100;
            health -= reducedDamage;
            shieldDurability--;
            if (shieldDurability <= 0)
            {
                hasShield = false;
                shieldCooldown = 2; 
                LockShieldButton();
            }
        }
        else
        {
            health -= damage;
        }
    }

    public void TakeDamage(Weapon weapon)
    {
        int damage = weapon.GetDamage();
        if (hasShield)
        {
            int reducedDamage = damage * (100 - shieldDamageReduction) / 100;
            health -= reducedDamage;
            shieldDurability--;
            if (shieldDurability <= 0)
            {
                hasShield = false;
                shieldCooldown = 5; 
                LockShieldButton(); 
            }
        }
        else
        {
            health -= damage;
        }

        weapon.ApllyEffect(this);
    }

    public void ToggleShield()
    {
        if (shieldCooldown > 0)
        {
            return;
        }
        
        if (!hasShield)
        {
            hasShield = true;
            shieldDurability = 5; 
        }
        else
        {
            hasShield = false;
        }
    }

    private void LockShieldButton()
    {
        shieldButton.interactable = false;
        Invoke("UnlockShieldButton", 2f); 
    }

    private void UnlockShieldButton()
    {
        shieldButton.interactable = true;
    }
}


