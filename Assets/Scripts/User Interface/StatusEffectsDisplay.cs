using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StatusEffectElement
{
    public GameObject statusEffectContainer;
    public Image icon;
    public Slider durationIndicator;

    public StatusEffectElement(GameObject statusEffectContainer, Image icon, Slider durationIndicator)
    {
        this.statusEffectContainer = statusEffectContainer;
        this.icon = icon;
        this.durationIndicator = durationIndicator;
    } 
}

public class StatusEffectsDisplay : MonoBehaviour
{
    [SerializeField] private GameObject statusEffectElementTemplate;
    private StatusEffectManager statusEffectManagerRef;
    [SerializeField] private Dictionary<StatusEffectClass, StatusEffectElement> currentStatusEffects;

    void Start()
    {
        currentStatusEffects = new();
        statusEffectManagerRef = GameObject.Find("PLAYER").GetComponent<StatusEffectManager>();
        statusEffectManagerRef.ApplyStatus += OnApplyStatusEffect;
        statusEffectManagerRef.UpdateStatusEffect += OnUpdateStatusEffect;
        statusEffectManagerRef.RemoveStatusEffect += OnRemoveStatusEffect;
    }

    private StatusEffectElement CreateStatusElement(StatusEffectClass statusEffect)
    {
        GameObject createdStatusElement = Instantiate(statusEffectElementTemplate, transform);
        Image statusIcon = createdStatusElement.transform.Find("Icon").GetComponent<Image>();
        statusIcon.sprite = statusEffect.icon;
        Slider durationIndicator = createdStatusElement.GetComponent<Slider>();
        durationIndicator.maxValue = statusEffect.duration;

        createdStatusElement.SetActive(true);
        durationIndicator.value = statusEffect.duration;
        return new StatusEffectElement(createdStatusElement, statusIcon, durationIndicator);
    }

    void OnApplyStatusEffect(StatusEffectClass statusEffect, float duration)
    {
        StatusEffectElement statusEffectElement = CreateStatusElement(statusEffect);
        currentStatusEffects.Add(statusEffect, statusEffectElement);

        OnUpdateStatusEffect(statusEffect, duration);
    }

    void OnUpdateStatusEffect(StatusEffectClass statusEffect, float duration)
    {
        currentStatusEffects[statusEffect].durationIndicator.value = duration;
    }

    void OnRemoveStatusEffect(StatusEffectClass statusEffect)
    {
        Destroy(currentStatusEffects[statusEffect].statusEffectContainer);
        currentStatusEffects.Remove(statusEffect);
    }
}
