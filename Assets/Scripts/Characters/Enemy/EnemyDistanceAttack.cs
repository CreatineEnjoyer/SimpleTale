using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyDistanceAttack : MonoBehaviour
{
    [SerializeField] private float BasicAttackCooldown;
    [SerializeField] private StatsScriptable enemyStats;
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject projectilePrefab;

    private float rangeAttack;
    private bool canAttack = true;
    private IDirection direction;
    private IAttackAnim attackAnimation;

    private void Start()
    {
        rangeAttack = enemyStats.AttackRange;
        direction = GetComponent<IDirection>();
        attackAnimation = GetComponentInParent<IAttackAnim>();
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

            Collider2D playerInRange = Physics2D.OverlapCapsule(transform.parent.position, new Vector2( rangeAttack * 2, 4f), CapsuleDirection2D.Horizontal, 0f, playerLayer);
            if (playerInRange != null)
            {
                attackAnimation.BasicAttackAnim();
                Shoot(projectilePrefab);
            }
            else
                attackAnimation.ResetAttackAnim();    
        }
    }

    private void Shoot(GameObject projectilePrefab)
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(BasicAttackCooldown);
        canAttack = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.parent.position, new Vector2(rangeAttack * 2, 4f));
    }
}
