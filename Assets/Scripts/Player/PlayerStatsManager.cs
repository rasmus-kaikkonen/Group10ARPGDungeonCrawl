using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public PlayerCharacter pc;

    public void UpdatePlayerStatsBasedOnArmor(Armor newItem, Armor oldItem)
    {
        if(oldItem != null)
        {
            pc.meleeResistance -= oldItem.meleeResistance;
            pc.magicResistance -= oldItem.magicResistance;
        }

        pc.meleeResistance += newItem.meleeResistance;
        pc.magicResistance += newItem.magicResistance;
    }
    

    public void UpdatePlayerDamageNumbers(Weapon newItem)
    {
        pc.meleeDamage = newItem.damage + (pc.Strength * ((100 + newItem.strengthMod) / 100)) + (pc.Dexterity * ((100 + newItem.dexMod) / 100));
    }
}
