using System;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField] private StatsScriptable enemyStats;
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient healthColor;
    [SerializeField] private Image contaminationProcess;
    [SerializeField] private GameObject[] prefabs;

    public event Action DeathEvent;
    private int health;
    private Animator animator;

    private void Start()
    {
        health = enemyStats.Health;
        animator = GetComponent<Animator>();
        slider.value = health;
        contaminationProcess.color = healthColor.Evaluate(1f);
    }

    void ITakeDamage.TakeDamage(int strength)
    {
        animator.SetTrigger("TakingHit");
        health -= strength;
        slider.value = health;
        contaminationProcess.color = healthColor.Evaluate(slider.normalizedValue);

        if (health <= 0)
        {
            foreach (GameObject prefab in prefabs) Instantiate(prefab, new Vector3(transform.position.x, (transform.position.y + 1), transform.position.z), Quaternion.identity);
            DeathEvent?.Invoke();
        }
    }
}
