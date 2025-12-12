using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(StatusEffectManager))]
public class PlayerCharacter : MonoBehaviour, IDamageable
{
    [field: Header("Main Stats")]
    [field: SerializeField] public int Level {get; set; } = 1;
    [field: SerializeField] public int Vitality { get; set; } = 5;
    [field: SerializeField] public int Strength { get; set; } = 5;
    [field: SerializeField] public int Dexterity { get; set; } = 5;
    [field: SerializeField] public int Spellpower { get; set; } = 5;
    [field: SerializeField] public int Luck { get; set; } = 5;
    [Header("HP")]
    [field: SerializeField] public float MaxHealth { get; set; }
    [field: SerializeField] public float CurrentHealth { get; set; }
    [field: Header("Other Stats")]
    [field: SerializeField] public int XPPoints { get; set; }
    public float meleeDamage = 10f;
    public float magicDamage = 10f;
    public float meleeResistance = 0;
    public float magicResistance = 0;
    [field: Header("Management")]
    public StatusBar healthBar;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private StatusEffectManager _statusEffectManager;
    public StatusEffectClass debugStatus;
    float MaxHitpoints()
    {
        float value = 0;
        value += 100 + 2 * Level + 5 * Vitality;
        return value;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _statusEffectManager = GetComponent<StatusEffectManager>();
        MaxHealth = MaxHitpoints();
        CurrentHealth = MaxHealth;
        healthBar.SetMaxValue(MaxHitpoints());
        meleeResistance = (float)Math.Round(0.8f * Level + 0.2f * Luck);
        magicResistance = (float)Math.Round(0.8f * Level + 0.3f * Luck);
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current[Key.F].wasPressedThisFrame)
        {
            Attack(meleeDamage);
        }
        if(Keyboard.current[Key.K].wasPressedThisFrame)
        {
            Damage(10);
        }
        if(Keyboard.current[Key.P].wasPressedThisFrame)
        {
            _statusEffectManager.ApplyEffect(debugStatus);
        }
    }

    public void Attack(float damage)
    {
        Debug.Log("Player attacked");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        damage += (float)Math.Round(Luck * 0.5);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().Damage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void Damage(float damageAmount)
    {
        damageAmount *= (100 - meleeResistance) / 100;
        CurrentHealth -= (float)Math.Floor(damageAmount);
        healthBar.SetValue(CurrentHealth);

        if(CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(0);
    }
}
