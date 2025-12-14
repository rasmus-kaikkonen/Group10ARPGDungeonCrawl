using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffDebuffElement
{
    public GameObject buffDebuffContainer;
    public Image icon;

    public BuffDebuffElement(GameObject buffDebuffContainer, Image icon)
    {
        this.buffDebuffContainer = buffDebuffContainer;
        this.icon = icon;
    }
}

public class BuffsDebuffsDisplay : MonoBehaviour
{
    [SerializeField] private GameObject buffDebuffTemplate;
    private BuffDebuffManager buffDebuffManagerRef;
    [SerializeField] private Dictionary<StatusEffectClass, BuffDebuffElement> currentBuffDebuffs;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBuffDebuffs = new();
        buffDebuffManagerRef = GameObject.Find("PLAYER").GetComponent<BuffDebuffManager>();
        buffDebuffManagerRef.ApplyBuffOrDebuff = OnApplyBuffOrDebuff;
        buffDebuffManagerRef.RemoveBuffOrDebuff = OnRemoveBuffOrDebuff;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private BuffDebuffElement CreateBuffDebuffElement(StatusEffectClass buffOrDebuff)
    {
        GameObject createdBuffDebuffElement = Instantiate(buffDebuffTemplate, transform);
        Image statusIcon = createdBuffDebuffElement.transform.Find("Icon").GetComponent<Image>();
        statusIcon.sprite = buffOrDebuff.icon;

        createdBuffDebuffElement.SetActive(true);
        return new BuffDebuffElement(createdBuffDebuffElement, statusIcon);
    }

    void OnApplyBuffOrDebuff(StatusEffectClass statusEffect, float duration)
    {
        BuffDebuffElement buffDebuffElement = CreateBuffDebuffElement(statusEffect);
        currentBuffDebuffs.Add(statusEffect, buffDebuffElement);
    }

    void OnRemoveBuffOrDebuff(StatusEffectClass statusEffect)
    {
        Destroy(currentBuffDebuffs[statusEffect].buffDebuffContainer);
        currentBuffDebuffs.Remove(statusEffect);
    }
}
