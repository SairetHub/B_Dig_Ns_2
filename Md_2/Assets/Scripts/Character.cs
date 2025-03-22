using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    [SerializeField] private Weapon activeWeapon;

    public Weapon ActiveWeapon
    {
        get { return activeWeapon; }
    }
    public virtual int Attack()
    {
        return activeWeapon.GetDamage();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(name + "health before hit " + health + " damage");
        health -= damage;
        Debug.Log(name + "health after hit " + health + " damage");
    }

    public void TakeDamage(Weapon weapon)
    {
        Debug.Log(name + "health before hit " + health + " damage");
        health -= weapon.GetDamage();
        weapon.ApllyEffect(this);
        Debug.Log(name + "health after hit " + health + " damage"); 
    }

}
