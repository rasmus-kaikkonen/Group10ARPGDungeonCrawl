using System.Collections.Generic;
using UnityEngine;

public enum WeaponScaling { S, A, B, C, D, NONE }

[CreateAssetMenu(fileName = "New Item", menuName = "Gameplay/Inventory/Weapon")]
public class Weapon : Equipment
{
    [Header("Scaling")]
    public WeaponScaling strScaling;
    public WeaponScaling dexScaling;
    public WeaponScaling spScaling;
    public WeaponScaling lckScaling;
    [Header("Base Damage")]
    public int physicalBaseDamage;
    public int magicBaseDamage;
    public int fireBaseDamage;
    public int darkBaseDamage;
    public int lightBaseDamage;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        Inventory.instance.RemoveItem(this);
        PlayerStatsManager.instance.UpdatePlayerDamageNumbers(this);
    }
}