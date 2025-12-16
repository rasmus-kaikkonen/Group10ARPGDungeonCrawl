using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatusEffectManager : MonoBehaviour
{
    public List<StatusEffectClass> currentEffects = new();
    [SerializeField] private float interval = 1f;
    private float currentInterval = 0f;
    private float lastInterval = 0f;

    public UnityAction<StatusEffectClass, float> ApplyStatus;
    public UnityAction<StatusEffectClass> RemoveStatusEffect;
    public UnityAction<StatusEffectClass, float> UpdateStatusEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentInterval += Time.deltaTime;
        if(currentInterval > lastInterval + interval)
        {
            UpdateEffects();
            lastInterval = currentInterval;
        }
    }

    public void ApplyEffect(StatusEffectClass statusEffect)
    {
        if(!currentEffects.Contains(statusEffect))
        {
            var statusEffectToAdd = Instantiate(statusEffect);
            statusEffectToAdd.ApplyEffect();
            currentEffects.Add(statusEffectToAdd);

            ApplyStatus?.Invoke(statusEffectToAdd, statusEffectToAdd.GetCurrentDurationNormalized());
        }
    }

    public void UpdateEffects()
    {
        for (int i = 0; i < currentEffects.Count; i++)
        {
            StatusEffectClass effect = currentEffects[i];
            effect.UpdateEffect(interval);

            UpdateStatusEffect?.Invoke(effect, effect.remainingDuration);

            if(effect.CanEffectBeRemoved())
            {
                RemoveEffect(effect);
            }
        }
    }

    public void RemoveEffect(StatusEffectClass statusEffect)
    {
        if(currentEffects.Contains(statusEffect))
        {
            currentEffects[currentEffects.IndexOf(statusEffect)].RemoveEffect();

            RemoveStatusEffect?.Invoke(currentEffects[currentEffects.IndexOf(statusEffect)]);

            currentEffects.Remove(statusEffect);
        }
    }
}
