using UnityEngine;

[CreateAssetMenu(fileName = "New Status Effect", menuName = "Gameplay/StatusEffects")]
public class StatusEffect : ScriptableObject
{
    new public string name = "New Status Effect";
    public Sprite icon;
    public float duration;
}
