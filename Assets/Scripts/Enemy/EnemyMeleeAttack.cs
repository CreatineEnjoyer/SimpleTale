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

        if (Distance())
        {
            sprite.flipX = false;
            if (attackPoint.localPosition.x < 0f)
            {
                flipPosition = attackPoint.localPosition;
                flipPosition.x *= -1;
                attackPoint.localPosition = flipPosition;
            }
        }
        else if (!Distance())
        {
            sprite.flipX = true;
            if (attackPoint.localPosition.x > 0f)
            {
                flipPosition = attackPoint.localPosition;
                flipPosition.x *= -1;
                attackPoint.localPosition = flipPosition;
            }
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
                collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(strength);
            }   
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(BasicAttackCooldown);
        canAttack = true;
    }
}
