using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float BasicAttackCooldown;
    [SerializeField] private StatsScriptable enemyStats;
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask playerLayer;
    
    private int strength;
    private float range;
    private bool canAttack = true;
    private SpriteRenderer sprite;
    private IAttackAnim attackAnimation;

    private void Start()
    {
        strength = enemyStats.Strength;
        range = enemyStats.AttackRange;
        attackAnimation = GetComponent<IAttackAnim>();
    }

    private void Awake()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        BasicAttack();
    }

    private void AttackDirection()
    {
        Vector3 flipPosition;
        flipPosition = attackPoint.localPosition;

        if (Distance())
        {
            sprite.flipX = false;
            if (attackPoint.localPosition.x < 0f)
                FlippingPosition(attackPoint, flipPosition);
        }
        else if (!Distance())
        {
            sprite.flipX = true;
            if (attackPoint.localPosition.x > 0f)
                FlippingPosition(attackPoint, flipPosition);
        }
    }

    private bool Distance()
    {
        if (player.transform.position.x > attackPoint.position.x) return true;
        else return false;
    }

    private void BasicAttack()
    {
        AttackDirection();

        if (canAttack)
        {
            canAttack = false;
            StartCoroutine(AttackCooldown());

            Collider2D[] playerInRange = Physics2D.OverlapCircleAll(attackPoint.position, range, playerLayer);
            foreach (Collider2D collider in playerInRange)
            {
                attackAnimation.BasicAttackAnim();
                collider.gameObject.GetComponent<ITakeDamage>().TakeDamage(strength);
            }   
        }
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

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(attackPoint.position, range);
    //}
}
