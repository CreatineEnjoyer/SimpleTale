using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private PlayerHealth health;

    void Start()
    {
        health = GetComponent<PlayerHealth>();
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
