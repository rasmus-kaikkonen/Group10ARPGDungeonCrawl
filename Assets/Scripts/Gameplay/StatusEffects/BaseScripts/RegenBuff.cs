using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RegenBuff", menuName = "Scriptable Objects/RegenBuff")]
public class RegenBuff : StatusEffectClass
{
    public float regenPotency = 10;

    public override void UpdateEffect(float tickAmount)
    {
        base.UpdateEffect(tickAmount);
        PlayerCharacter playerChar = GameObject.Find("PLAYER").GetComponent<PlayerCharacter>();
        if(isEffectActive)
        {
            playerChar.CurrentHealth += (float)Math.Round(playerChar.MaxHealth * (regenPotency / 100));
        }
    }
}
