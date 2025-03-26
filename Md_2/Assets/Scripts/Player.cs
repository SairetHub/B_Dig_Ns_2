using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public string CharName;

    public void ToggleShield()
    {
        if (hasShield)
        {
            hasShield = false;
        }
        else
        {
            hasShield = true;
            shieldDurability = 3;
        }
    }
}
