using System.Collections.Generic;
using UnityEngine;

public enum WeaponScaling { S, A, B, C, D, NONE }

[CreateAssetMenu(fileName = "New Item", menuName = "Gameplay/Inventory/Weapon")]
public class Weapon : Equipment
{
    public float damage;
    public float strengthMod;
    public float dexMod;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        Inventory.instance.RemoveItem(this);
        PlayerStatsManager.instance.UpdatePlayerDamageNumbers(this);
    }
}