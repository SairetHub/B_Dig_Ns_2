using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonWeapon : Weapon
{
    [SerializeField] private int poisonDamage = 2;
    public override void ApllyEffect(Character character)
    {
        character.TakeDamage(poisonDamage);
        Debug.Log(character.name + "took" + poisonDamage + "Poison damage");
    }
}
