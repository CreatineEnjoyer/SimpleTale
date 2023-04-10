using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private DetectionRangeScriptable enemyDetectionStats;
    [SerializeField] private AttackScriptable enemyAttackStats;

    private SpriteRenderer sprite;
    float distanceToPlayer = 0f;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < enemyDetectionStats.DetectionRange && distanceToPlayer > enemyAttackStats.Range)
        {
            StartCoroutine(MoveTowardsPlayer());
        }
    }

    private IEnumerator MoveTowardsPlayer()
    {
        Vector2 destination = Vector2.MoveTowards(transform.position, player.transform.position, enemyDetectionStats.MovementSpeed * Time.deltaTime);
        destination.y = transform.position.y;
        transform.position = destination;

        MovingDirection(player);
        yield return null;
    }

    
    private void MovingDirection(GameObject player)
    {
        if (player.transform.position.x < 0f)
        {
            sprite.flipX = true;
        }
        else if (player.transform.position.x > 0f)
        {
            sprite.flipX = false;
        }
    }
    
}
