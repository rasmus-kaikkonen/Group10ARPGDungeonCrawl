using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BleedStatus", menuName = "Scriptable Objects/BleedStatus")]
public class BleedStatus : StatusEffectClass
{
    public float bleedPotency = 5;

    public override void UpdateEffect(float tickAmount)
    {
        base.UpdateEffect(tickAmount);
        PlayerCharacter playerChar = GameObject.Find("PLAYER").GetComponent<PlayerCharacter>();
        if(isEffectActive)
        {
            playerChar.CurrentHealth -= (float)Math.Round(playerChar.MaxHealth * (bleedPotency / 100));
        }
    }
}
