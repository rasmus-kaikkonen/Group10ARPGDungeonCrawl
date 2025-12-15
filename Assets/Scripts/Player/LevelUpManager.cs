using System;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public static LevelUpManager instance;

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

    public PlayerCharacter playerCharacter;
    public PlayerStatsManager playerStatsManagerRef;
    public int levelMax = 99;
    public int statPoints = 2;

    void Update()
    {
        if(LevelUpAvailable())
        {
            LevelUP();
        }
    }

    public int MaxXP()
    {
        return (int)Math.Pow(playerCharacter.Level, 4) * 100;
    }

    public bool LevelUpAvailable()
    {
        return playerCharacter.XPPoints >= MaxXP() && playerCharacter.Level < levelMax;
    }

    public void AddXP(int xpToAdd)
    {
        playerStatsManagerRef.UpdateXP(xpToAdd);
    }

    public void LevelUP()
    {
        playerCharacter.XPPoints = 0;
        playerCharacter.Level++;
        playerStatsManagerRef.UpdatePlayerMainStats(statPoints);
    }
}
