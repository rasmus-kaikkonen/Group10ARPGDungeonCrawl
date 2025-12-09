using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager instance;
    public List<float> weaponsScaling = new();

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

    void Start()
    {
        weaponsScaling.Add(1.09f);
        weaponsScaling.Add(1.16f);
        weaponsScaling.Add(1.32f);
        weaponsScaling.Add(1.68f);
        weaponsScaling.Add(1.96f);
        weaponsScaling.Add(0);
    }

    public PlayerCharacter playerCharacter;

    public void UpdatePlayerStatsBasedOnArmor(Armor newItem, Armor oldItem)
    {
        if(oldItem != null)
        {
            playerCharacter.physicalResist -= oldItem.physicalResist;
            playerCharacter.magicResist -= oldItem.magicResist;
            playerCharacter.fireResist -= oldItem.fireResist;
            playerCharacter.lightResist -= oldItem.lightResist;
            playerCharacter.darkResist -= oldItem.darkResist;
        }

        playerCharacter.physicalResist = playerCharacter.physicalBaseResist + newItem.physicalResist;
        playerCharacter.magicResist = playerCharacter.magicBaseResist + newItem.magicResist;
        playerCharacter.fireResist = playerCharacter.lightBaseResist + newItem.fireResist;
        playerCharacter.lightResist = playerCharacter.lightBaseResist + newItem.lightResist;
        playerCharacter.darkResist = playerCharacter.darkBaseResist + newItem.darkResist;
    }
    

    public void UpdatePlayerDamageNumbers(Weapon newItem)
    {
        playerCharacter.physicalDamage = newItem.physicalBaseDamage + ((int)Math.Floor(playerCharacter.Strength * weaponsScaling[(int)newItem.strScaling])) + ((int)Math.Floor(playerCharacter.Dexterity * weaponsScaling[(int)newItem.dexScaling]));
        playerCharacter.magicDamage = newItem.magicBaseDamage + (playerCharacter.Spellpower * ((int)Math.Floor(weaponsScaling[(int)newItem.spScaling])));
        playerCharacter.fireDamage = newItem.fireBaseDamage + ((int)Math.Floor(playerCharacter.Spellpower * weaponsScaling[(int)newItem.spScaling])) + ((int)Math.Floor(playerCharacter.Luck * weaponsScaling[(int)newItem.lckScaling]));
        playerCharacter.lightDamage = newItem.lightBaseDamage + ((int)Math.Floor(playerCharacter.Spellpower * weaponsScaling[(int)newItem.spScaling]));
        playerCharacter.darkDamage = newItem.darkBaseDamage + ((int)Math.Floor(playerCharacter.Luck * weaponsScaling[(int)newItem.lckScaling]));
    }
}
