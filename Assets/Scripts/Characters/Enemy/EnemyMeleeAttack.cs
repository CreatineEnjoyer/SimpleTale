using System.Collections;
using Unity.VisualScripting;
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
    private SpriteRenderer sprite;
    private IAttackAnim attackAnimation;

    private void Start()
    {
        strength = enemyStats.Strength;
        range = enemyStats.AttackRange;
        attackCollision = GetComponent<CircleCollider2D>();
        attackCollision.radius = range;
        attackAnimation = GetComponentInParent<IAttackAnim>();
    }

    private void Awake()
    {
        sprite = GetComponentInParent<SpriteRenderer>();
    }

    private void Update()
    {
        AttackAnimated();
    }

    private void AttackDirection()
    {
        Vector3 flipPosition;
        flipPosition = transform.localPosition;

        if (Distance())
        {
            sprite.flipX = false;
            if (transform.localPosition.x < 0f)
                FlippingPosition(transform, flipPosition);
        }
        else if (!Distance())
        {
            sprite.flipX = true;
            if (transform.localPosition.x > 0f)
                FlippingPosition(transform, flipPosition);
        }
    }

    private bool Distance()
    {
        if (player.transform.position.x - transform.parent.position.x > 0f) return true;
        else return false;
    }

    private void AttackAnimated()
    {
        if (canAttack)
        {
            canAttack = false;
            StartCoroutine(AttackCooldown());
            AttackDirection();

            Collider2D playerInRange = Physics2D.OverlapCircle(transform.position, range, playerLayer);
            if (playerInRange != null)
            {
                attackAnimation.BasicAttackAnim();
            }
            else
                attackAnimation.ResetAttackAnim();
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

    private void FlippingPosition(Transform attackPoint, Vector3 flipPosition)
    {
        flipPosition.x *= -1;
        attackPoint.localPosition = flipPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (attackCollision != null)
            Gizmos.DrawWireSphere(transform.position, range);
    }
}
