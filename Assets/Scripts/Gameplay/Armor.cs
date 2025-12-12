using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Gameplay/Inventory/Armor")]
public class Armor : Equipment
{
    [Header("Resistances")]
    public float meleeResistance;
    public float magicResistance;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        Inventory.instance.RemoveItem(this);
    }
}
