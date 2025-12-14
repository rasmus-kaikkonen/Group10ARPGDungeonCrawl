using UnityEngine;

[CreateAssetMenu(fileName = "DefenceBuff", menuName = "Scriptable Objects/DefenceBuff")]
public class DefenceBuff : StatusEffectClass
{
    public float defenceBuff;

    public override void ApplyEffect()
    {
        base.ApplyEffect();
        PlayerCharacter playerChar = GameObject.Find("PLAYER").GetComponent<PlayerCharacter>();
        playerChar.meleeResistance *= defenceBuff / 100;
    }

    public override void RemoveEffect()
    {
        base.RemoveEffect();
        PlayerCharacter playerChar = GameObject.Find("PLAYER").GetComponent<PlayerCharacter>();
        playerChar.meleeResistance /= defenceBuff / 100;
    }
}
