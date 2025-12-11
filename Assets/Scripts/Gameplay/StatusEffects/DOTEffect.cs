using UnityEngine;

[CreateAssetMenu(fileName = "New DoT Effect", menuName = "Gameplay/DoT")]
public class DOTEffect : StatusEffectClass
{
    public float DoTDamage = 5f;

    public override void UpdateEffect(float tickAmount)
    {
        base.UpdateEffect(tickAmount);
        if(isEffectActive)
        {
            GameObject.Find("PLAYER").GetComponent<PlayerCharacter>().CurrentHealth -= DoTDamage;
        }
    }
}