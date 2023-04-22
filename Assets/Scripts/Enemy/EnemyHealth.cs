using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    private StatsScriptable enemyStats;

    public event Action DeathEvent;
    private int health;

    private void Start()
    {
        health = enemyStats.Health;
    }

    void ITakeDamage.TakeDamage(int strength)
    {
        health -= strength;
        if(health <= 0) DeathEvent?.Invoke();
    }
}
