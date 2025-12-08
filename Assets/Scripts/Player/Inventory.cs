using System.Collections.Generic;
using UnityEngine;

public enum ItemAction { USE, EQUIP, DROP }

public class Inventory : MonoBehaviour
{
    public List<Item> items = new();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public static Inventory instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        onItemChangedCallback?.Invoke();
    }

    public void RemoveItem(Item item)
    {
        items.Add(item);
        onItemChangedCallback?.Invoke();
    }
}
