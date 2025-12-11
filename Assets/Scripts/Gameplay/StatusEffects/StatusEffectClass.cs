using UnityEngine;

public enum StatusEffectType
{
    BUFF,
    DEBUFF,
    DOT,
    OTHER
}

public abstract class StatusEffectClass : ScriptableObject
{
    new public string name = "New Status Effect";
    public StatusEffectType type;
    public Sprite icon;
    public float duration;
    public float remainingDuration;
    public bool isEffectActive;

    public virtual void ApplyEffect()
    {
        isEffectActive = true;
        remainingDuration = duration;
    }
    public virtual void UpdateEffect(float tickAmount)
    {
        if(isEffectActive)
        {
            remainingDuration -= tickAmount;

            if(remainingDuration <= 0)
            {
                isEffectActive = false;
            }
        }
    }
    public virtual void RemoveEffect()
    {
        isEffectActive = false;
        remainingDuration = 0;
    }

    public virtual bool CanEffectBeRemoved()
    {
        return !isEffectActive;
    }

    public virtual float GetCurrentDurationNormalized()
    {
        return remainingDuration / duration;
    }
}
