using UnityEngine;

[CreateAssetMenu(fileName = "BurnStatus", menuName = "Scriptable Objects/BurnStatus")]
public class BurnStatus : StatusEffectClass
{
    public float burnDamage = 5;

    public override void UpdateEffect(float tickAmount)
    {
        base.UpdateEffect(tickAmount);
        PlayerCharacter playerChar = GameObject.Find("PLAYER").GetComponent<PlayerCharacter>();
        if(isEffectActive)
        {
            playerChar.CurrentHealth -= 5;
        }
    }
}
