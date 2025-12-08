using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    #region Main Stats
    [field: Header("Main Stats")]
    [field: SerializeField] public int Level {get; set; } = 1;
    [field: SerializeField] public int Vitality { get; set; } = 5;
    [field: SerializeField] public int Vigour { get; set; } = 5;
    [field: SerializeField] public int Strength { get; set; } = 5;
    [field: SerializeField] public int Dexterity { get; set; } = 5;
    [field: SerializeField] public int Spellpower { get; set; } = 5;
    [field: SerializeField] public int Luck { get; private set; } = 5;
    #endregion
    #region HP And Stamina
    [field: Header("HP And Stamina")]
    [field: SerializeField] public int HitPoints { get; set; }
    [field: SerializeField] public int Stamina { get; set; }
    #endregion
    #region Advancement
    [field: Header("Advancement")]
    [field: SerializeField] public int XPPoints { get; set; }
    #endregion
    #region Status Effects And Buffs/Debuffs
    [field: Header("Status Effects And Buffs/Debuffs")]
    [field: SerializeField] public List<StatusEffect> StatusEffects { get; set; }
    [field: SerializeField] public List<StatusEffect> BuffsDebuffs { get; set; }
    #endregion
    #region Management
    [field: Header("Management")]
    public StatusBar healthBar;
    public StatusBar staminaBar;
    #endregion
    int MaxHitpoints()
    {
        int value = 0;
        value += (int)Math.Ceiling(140 + (2.35 * Level) + (3.35 * Vitality));
        return value;
    }

    int MaxStamina()
    {
        int value = 0;
        value += (int)Math.Ceiling(100 + (1.4 * Level) + (2.15 * Vigour));
        return value;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HitPoints = MaxHitpoints();
        Stamina = MaxStamina();
        healthBar.SetMaxValue(MaxHitpoints());
        staminaBar.SetMaxValue(MaxStamina());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleDamage()
    {
        
    }
}
