using UnityEngine;

public class CharacterDeath : MonoBehaviour
{
    private ITakeDamage health;

    void Start()
    {
        health = GetComponent<ITakeDamage>();
        health.DeathEvent += Die;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        health.DeathEvent -= Die;
    }
}
