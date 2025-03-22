using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Enemy
{
    [SerializeField] private int agressionGain = 10;
    
    public override int Attack()
    {
        aggresion += agressionGain;
        return ActiveWeapon.GetDamage() + aggresion / 10;
    }
}
