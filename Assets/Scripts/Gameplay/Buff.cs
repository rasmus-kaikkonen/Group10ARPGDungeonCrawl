using UnityEngine;

[CreateAssetMenu(fileName = "New Buff", menuName = "Gameplay/StatusEffects/Buffs")]
public class Buff : StatusEffect
{
    new public string name = "New Buff";

    public override void ProcessEffect()
    {
        base.ProcessEffect();
    }
}