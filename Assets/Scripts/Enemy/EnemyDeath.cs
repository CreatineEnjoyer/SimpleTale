using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    // Update is called once per frame

    EnemyHealth health;
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        health.deathEvent += Die;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        health.deathEvent -= Die;
    }
}
