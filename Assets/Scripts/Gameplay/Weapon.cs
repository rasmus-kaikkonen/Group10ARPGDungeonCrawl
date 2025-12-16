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
        GameObject.Find("GameManager").GetComponent<EquipmentManager>().Equip(this);
        GameObject.Find("GameManager").GetComponent<Inventory>().RemoveItem(this);
        GameObject.Find("GameManager").GetComponent<PlayerStatsManager>().UpdatePlayerDamageNumbers(this);
    }
}