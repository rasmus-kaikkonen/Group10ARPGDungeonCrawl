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

    void Start()
    {
        
    }

    public PlayerCharacter playerCharacter;

    public void UpdatePlayerStatsBasedOnArmor(Armor newItem, Armor oldItem)
    {

    }
    

    public void UpdatePlayerDamageNumbers(Weapon newItem)
    {

    }
}
