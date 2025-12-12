using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Gameplay/Inventory/HealthItem")]
public class HealthItem : Item
{
    public float healAmmount;
    public override void Use()
    {
        Inventory.instance.RemoveItem(this);
        PlayerStatsManager.instance.pc.CurrentHealth += healAmmount;
    }
}
