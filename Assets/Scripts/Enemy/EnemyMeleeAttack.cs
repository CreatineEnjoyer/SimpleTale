using System.Collections;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float BasicAttackCooldown;
    [SerializeField] private AttackScriptable enemyAttackStats;
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask playerLayer;
    
    private int strength;
    private float range;
    private bool canAttack = true;
    private SpriteRenderer sprite;


    private void Start()
    {
        strength = enemyAttackStats.Strength;
        range = enemyAttackStats.Range;
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
            FlippingPosition(attackPoint, flipPosition);
        }
        else if (!Distance())
        {
            sprite.flipX = true;
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
            //animator.SetTrigger("Attacking");

            canAttack = false;
            StartCoroutine(AttackCooldown());

            Collider2D[] playerInRange = Physics2D.OverlapCircleAll(attackPoint.position, range, playerLayer);
            foreach (Collider2D collider in playerInRange)
            {
                collider.gameObject.GetComponent<ITakingDamage>().TakeDamage(strength);
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
        if (attackPoint.localPosition.x != 0f)
        {
            flipPosition.x *= -1;
            attackPoint.localPosition = flipPosition;
        }
    }
}
