using UnityEngine;

[CreateAssetMenu(fileName = "PoisonStatus", menuName = "Scriptable Objects/PoisonStatus")]
public class PoisonStatus : StatusEffectClass
{
    public float poisonDamage = 2;

    public override void UpdateEffect(float tickAmount)
    {
        base.UpdateEffect(tickAmount);
        PlayerCharacter playerChar = GameObject.Find("PLAYER").GetComponent<PlayerCharacter>();
        if(isEffectActive)
        {
            playerChar.CurrentHealth -= poisonDamage;
        }
    }
}
