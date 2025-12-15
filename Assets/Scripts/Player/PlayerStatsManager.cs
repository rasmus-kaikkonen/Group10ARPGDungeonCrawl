using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatsManager : MonoBehaviour
{
    public UnityAction OnStatusChangedCallback;

    public PlayerCharacter pc;

    public void InitPlayerStats()
    {
        pc.MaxHealth = pc.MaxHitpoints();
        pc.CurrentHealth = pc.MaxHealth;
        
        pc.baseMeleeResistance = (float)Math.Round(0.8f * pc.Level + 0.2f * pc.Luck);
        pc.meleeResistance = pc.baseMeleeResistance;
        pc.baseMagicResistance = (float)Math.Round(0.8f * pc.Level + 0.3f * pc.Luck);
        pc.magicResistance = pc.baseMagicResistance;
        OnStatusChangedCallback?.Invoke();
    }

    public void UpdatePlayerStatsBasedOnArmor(Armor newItem, Armor oldItem)
    {
        if(oldItem != null)
        {
            pc.meleeResistance -= oldItem.meleeResistance;
            pc.magicResistance -= oldItem.magicResistance;
        }

        pc.meleeResistance = pc.baseMeleeResistance + newItem.meleeResistance;
        pc.magicResistance = pc.baseMagicResistance + newItem.magicResistance;

        OnStatusChangedCallback?.Invoke();
    }
    

    public void UpdatePlayerDamageNumbers(Weapon newItem)
    {
        pc.meleeDamage = newItem.damage + (pc.Strength * ((100 + newItem.strengthMod) / 100)) + (pc.Dexterity * ((100 + newItem.dexMod) / 100));

        OnStatusChangedCallback?.Invoke();
    }

    public void UpdatePlayerMainStats(int pointAmount)
    {
        pc.Vitality += pointAmount;
        pc.Strength += pointAmount;
        pc.Dexterity += pointAmount;
        pc.Spellpower += pointAmount;
        pc.Luck += pointAmount;
        pc.MaxHealth = pc.MaxHitpoints();
        pc.baseMeleeResistance = (float)Math.Round(0.8f * pc.Level + 0.2f * pc.Luck);
        pc.baseMagicResistance = (float)Math.Round(0.8f * pc.Level + 0.3f * pc.Luck);

        OnStatusChangedCallback?.Invoke();
    }

    public void UpdateXP(int xpToAdd)
    {
        pc.XPPoints += xpToAdd;
        OnStatusChangedCallback?.Invoke();
    }
}
