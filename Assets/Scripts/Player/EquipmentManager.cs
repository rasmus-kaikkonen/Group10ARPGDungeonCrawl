using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Equipment[] currentEquipment;
    public PlayerStatsManager playerStatsManagerRef;

    public delegate void OnEquipmentChangedCallback();
    public OnEquipmentChangedCallback onEquipmentChangedCallback;

    public Inventory inventoryRef;

    void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipType)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        int equipSlot = (int)newItem.equipType;

        Equipment oldItem = null;

        if(currentEquipment[equipSlot] != null)
        {
            oldItem = currentEquipment[equipSlot];
            inventoryRef.AddItem(oldItem);
        }

        currentEquipment[equipSlot] = newItem;

        playerStatsManagerRef.UpdatePlayerStatsBasedOnArmor((Armor)newItem, (Armor)oldItem);

        onEquipmentChangedCallback.Invoke();
    }
}
