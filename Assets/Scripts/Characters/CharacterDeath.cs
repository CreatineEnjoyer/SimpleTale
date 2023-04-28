using UnityEngine;

public class CharacterDeath : MonoBehaviour
{
    private ITakeDamage health;
    [SerializeField] private Animator animator;

    void Start()
    {
        health = GetComponent<ITakeDamage>();
        health.DeathEvent += Die;
    }
    void DeathAnimation()
    {
        if(animator != null)
            animator.SetTrigger("Death");
    }

    void Disappear()
    {
        gameObject.SetActive(false);
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
