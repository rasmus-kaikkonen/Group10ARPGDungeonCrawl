using UnityEngine;

public enum ItemType { USABLE, EQUPMENT }

[CreateAssetMenu(fileName = "Item", menuName = "Gameplay/Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public ItemType type;

    public virtual void Use()
    {
        //override
    }

    public virtual void Drop()
    {
        //override
    }
}
