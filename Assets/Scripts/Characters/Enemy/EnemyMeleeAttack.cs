using System.Collections;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private float BasicAttackCooldown;
    [SerializeField] private StatsScriptable enemyStats;
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask playerLayer;

    private CircleCollider2D attackCollision;
    private int strength;
    private float range;
    private bool canAttack = true;
    private IAttackAnim attackAnimation;
    private IDirection direction;

    private void Start()
    {
        strength = enemyStats.Strength;
        range = enemyStats.AttackRange;
        attackCollision = GetComponent<CircleCollider2D>();
        attackCollision.radius = range;
        attackAnimation = GetComponentInParent<IAttackAnim>();
        direction = GetComponent<IDirection>();
    }

    private void Update()
    {
        AttackAnimated();
    }

    private void AttackAnimated()
    {
        if (canAttack)
        {
            canAttack = false;
            StartCoroutine(AttackCooldown());
            direction.AttackDirection();

            Collider2D playerInRange = Physics2D.OverlapCircle(transform.position, range, playerLayer);
            if (attackAnimation != null)
            {
                if (playerInRange != null)
                {
                    attackAnimation.BasicAttackAnim();
                }
                else
                    attackAnimation.ResetAttackAnim();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
            player.GetComponent<ITakeDamage>().TakeDamage(strength);
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(BasicAttackCooldown);
        canAttack = true;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    if (attackCollision != null)
    //        Gizmos.DrawWireSphere(transform.position, range);
    //}
}
