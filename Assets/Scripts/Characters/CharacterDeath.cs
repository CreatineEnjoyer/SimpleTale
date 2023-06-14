using System;
using UnityEngine;

public class CharacterDeath : MonoBehaviour
{
    private ITakeDamage health;
    [SerializeField] private Animator animator;
    public event Action BossDeathEvent;

    void Start()
    {
        health = GetComponent<ITakeDamage>();
        health.DeathEvent += Die;
    }
    void DeathAnimation()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        if(animator != null)
            animator.SetTrigger("Death");
    }

    void Disappear()
    {
        gameObject.SetActive(false);
        BossDeathEvent?.Invoke();
    }

    private void Die()
    {
        DeathAnimation();
        Invoke(nameof(Disappear), 0.4f);
    }

    private void OnDisable()
    {
        health.DeathEvent -= Die;
    }
}
