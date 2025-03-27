using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private int _health = 100;
    public bool hasShield = false;
    public int shieldDurability = 5;
    public int shieldDamageReduction = 50;
    private int shieldCooldown = 0;

    [SerializeField] private Weapon activeWeapon;
    [SerializeField] private Button shieldButton;

    public int Health
    {
        get { return _health; }
        set
        {
            _health = Mathf.Clamp(value, 0, 100);

            if (_health == 0)
            {
                Debug.Log(name + " is dead!");

                if (this is Player)
                {
                    GameManager.Instance.GameOver();
                }
            }
        }
    }

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
            Health -= reducedDamage;
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
            Health -= damage;
        }
    }

    public void TakeDamage(Weapon weapon)
    {
        int damage = weapon.GetDamage();
        if (hasShield)
        {
            int reducedDamage = damage * (100 - shieldDamageReduction) / 100;
            Health -= reducedDamage;
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
            Health -= damage;
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


