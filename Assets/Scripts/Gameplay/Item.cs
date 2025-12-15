using UnityEngine;

public enum ItemType { USABLE, EQUPMENT }

public class Item : ScriptableObject
{
    [Header("Standard Info")]
    new public string name = "New Item";
    public ItemType type;

    public virtual void Use()
    {
        //override
    }

    public virtual void Drop()
    {
        GameObject.Find("GameManager").GetComponent<Inventory>().RemoveItem(this);
    }
}
