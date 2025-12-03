using System;
using UnityEngine;

public class MainStats : MonoBehaviour
{
    [field: SerializeField] public int Level {get; private set; } = 1;
    [field: SerializeField] public int Vitality { get; private set; } = 5;
    [field: SerializeField] public int Vigour { get; private set; } = 5;
    [field: SerializeField] public int Strength { get; private set; } = 5;
    [field: SerializeField] public int Dexterity { get; private set; } = 5;
    [field: SerializeField] public int Spellpower { get; private set; } = 5;
    [field: SerializeField] public int Luck { get; private set; } = 5;
    [field: SerializeField] public float HitPoints { get; private set; }
    [field: SerializeField] public float Stamina { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HitPoints = (float)Math.Ceiling(140 + (2.35 * Level) + (3.35 * Vitality));
        Stamina = (float)Math.Ceiling(100 + (1.4 * Level) + (2.15 * Vigour));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
