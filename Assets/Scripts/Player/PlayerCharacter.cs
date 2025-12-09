using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, IDamageable
{
    #region Main Stats
    [field: Header("Main Stats")]
    [field: SerializeField] public int Level {get; set; } = 1;
    [field: SerializeField] public int Vitality { get; set; } = 5;
    [field: SerializeField] public int Vigour { get; set; } = 5;
    [field: SerializeField] public int Strength { get; set; } = 5;
    [field: SerializeField] public int Dexterity { get; set; } = 5;
    [field: SerializeField] public int Spellpower { get; set; } = 5;
    [field: SerializeField] public int Luck { get; set; } = 5;
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
    #region Damage
    [field: Header("Damage")]
    public int physicalDamage = 0;
    public int magicDamage = 0;
    public int fireDamage = 0;
    public int darkDamage = 0;
    public int lightDamage = 0;
    #endregion
    #region Resistances
    [field: Header("Resistances")]
    public int physicalBaseResist = 0;
    public int magicBaseResist = 0;
    public int fireBaseResist = 0;
    public int darkBaseResist = 0;
    public int lightBaseResist = 0;
    public int physicalResist = 0;
    public int magicResist = 0;
    public int fireResist = 0;
    public int darkResist = 0;
    public int lightResist = 0;
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

    public void TakeDamage(DamageStruct damage)
    {
        float physicalDamage = damage.physicalDamage * (physicalResist / 100);
        float magicDamage = damage.magicDamage * (magicResist / 100);
        float fireDamage = damage.fireDamage * (fireResist / 100);
        float darkDamage = damage.darkDamage * (darkResist / 100);
        float lightDamage = damage.lightDamage * (lightResist / 100);

        float totalDamage = physicalDamage + magicDamage + fireDamage + darkDamage + lightDamage;

        HitPoints -= (int)Math.Floor(totalDamage);
    }

    public DamageStruct HandleDamage()
    {
        DamageStruct damage;
        damage.physicalDamage = physicalDamage;
        damage.magicDamage = magicDamage;
        damage.fireDamage = fireDamage;
        damage.lightDamage = lightDamage;
        damage.darkDamage = darkDamage;

        return damage;
    }

    public void Attack()
    {
        
    }
}
