using UnityEngine;

public enum WeaponScaling { S, A, B, C, D, NONE }

[CreateAssetMenu(fileName = "New Item", menuName = "Gameplay/Inventory/Weapon")]
public class Weapon : Equipment
{
    public WeaponScaling strScaling;
    public WeaponScaling dexScaling;
    public WeaponScaling spScaling;
    public WeaponScaling lckScaling;
    public int damage;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        Inventory.instance.RemoveItem(this);
    }
}