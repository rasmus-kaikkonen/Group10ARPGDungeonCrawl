using UnityEngine;

public enum StatusEffectType
{
    BUFF,
    DEBUFF,
    STATUSEFFECT
}

[CreateAssetMenu(fileName = "New Status Effect", menuName = "Gameplay/StatusEffects")]
public class StatusEffect : ScriptableObject
{
    new public string name = "New Status Effect";
    public StatusEffectType type;
    public Sprite icon;
    public float duration;

    public virtual void ProcessEffect() {}
}
