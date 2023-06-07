using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField] private StatsScriptable enemyStats;
    [SerializeField] private GameObject[] prefabs;

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
        if (health <= 0)
        {
            foreach (GameObject prefab in prefabs) Instantiate(prefab, new Vector3(transform.position.x, (transform.position.y + 1), transform.position.z), Quaternion.identity);
            DeathEvent?.Invoke();
        }
    }
}
