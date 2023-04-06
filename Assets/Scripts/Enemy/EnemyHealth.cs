using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private HealthScriptable enemyHealth;

    public event Action DeathEvent;

    private int health;

    private void Start()
    {
        health = enemyHealth.Health;
    }

    public int GetHealth()
    {
        return health;
    }

    public void TakeDamage(int playerStrength)
    {
        health -= playerStrength;
        if(health <= 0) DeathEvent?.Invoke();
    }
}
