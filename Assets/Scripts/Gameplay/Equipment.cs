using UnityEngine;

public enum EquipType { HAND, HEAD, NECK, TORSO, RING }

public class Equipment : Item
{
    public EquipType equipType;

    public override void Use()
    {
        base.Use();
        GameObject.Find("GameManager").GetComponent<EquipmentManager>().Equip(this);
        GameObject.Find("GameManager").GetComponent<Inventory>().RemoveItem(this);
    }
}