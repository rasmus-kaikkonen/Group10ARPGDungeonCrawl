using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Gameplay/Inventory/Armor")]
public class Armor : Equipment
{
    [Header("Resistances")]
    public int physicalResist = 0;
    public int magicResist = 0;
    public int fireResist = 0;
    public int darkResist = 0;
    public int lightResist = 0;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        Inventory.instance.RemoveItem(this);
    }
}
