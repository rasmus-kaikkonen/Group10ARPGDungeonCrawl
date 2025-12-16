using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackPowerBuff", menuName = "Scriptable Objects/AttackPowerBuff")]
public class AttackPowerBuff : StatusEffectClass
{
    public float attackBuff;

    public override void ApplyEffect()
    {
        base.ApplyEffect();
        PlayerCharacter playerChar = GameObject.Find("PLAYER").GetComponent<PlayerCharacter>();
        playerChar.meleeDamage *= attackBuff / 100;
    }

    public override void RemoveEffect()
    {
        base.RemoveEffect();
        PlayerCharacter playerChar = GameObject.Find("PLAYER").GetComponent<PlayerCharacter>();
        playerChar.meleeDamage /= attackBuff / 100;
    }
}
