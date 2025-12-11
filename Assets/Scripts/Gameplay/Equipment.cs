using UnityEngine;

public enum EquipType { HAND, HEAD, NECK, TORSO, RING }

public class Equipment : Item
{
    public EquipType equipType;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        Inventory.instance.RemoveItem(this);
    }
}