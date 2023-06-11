using UnityEngine;

public class Doll : MonoBehaviour
{
    [SerializeField] private StatsScriptable bossHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetType() == typeof(CapsuleCollider2D) && collision.gameObject.layer == 7)
        {
            collision.GetComponent<ITakeDamage>().TakeDamage(bossHealth.Health);
            Destroy(gameObject);
        } 
        else if (collision.GetType() != typeof(BoxCollider2D) && collision.gameObject.layer != 7)
        {
            Destroy(gameObject);
        }
    }
}
