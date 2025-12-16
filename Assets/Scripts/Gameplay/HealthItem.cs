using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Gameplay/Inventory/HealthItem")]
public class HealthItem : Item
{
    public float healAmmount;
    public override void Use()
    {
        GameObject.Find("GameManager").GetComponent<Inventory>().RemoveItem(this);
        GameObject.Find("GameManager").GetComponent<PlayerStatsManager>().pc.CurrentHealth += healAmmount;
    }
}
