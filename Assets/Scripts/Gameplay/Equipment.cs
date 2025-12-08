using UnityEngine;

public enum EquipType { HAND, HEAD, NECK, TORSO, RING }

[CreateAssetMenu(fileName = "New Item", menuName = "Gameplay/Inventory/Equipment")]
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