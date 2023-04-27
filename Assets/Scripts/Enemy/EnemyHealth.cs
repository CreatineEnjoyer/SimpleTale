using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField] private StatsScriptable enemyStats;

    public event Action DeathEvent;
    private int health;
    private Animator animator;

    private void Start()
    {
        health = enemyStats.Health;
        animator = GetComponent<Animator>();
    }

    void ITakeDamage.TakeDamage(int strength)
    {
        animator.SetTrigger("TakingHit");
        health -= strength;
        if (health <= 0) DeathEvent?.Invoke();
    }
}
