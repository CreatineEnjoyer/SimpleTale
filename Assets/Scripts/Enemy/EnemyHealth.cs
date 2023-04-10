using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, ITakingDamage
{
    [SerializeField]
    private HealthScriptable enemyHealth;

    public event Action DeathEvent;

    private int health;

    private void Start()
    {
        health = enemyHealth.Health;
    }

    public void TakeDamage(int strength)
    {
        health -= strength;
        if(health <= 0) DeathEvent?.Invoke();
    }
}
