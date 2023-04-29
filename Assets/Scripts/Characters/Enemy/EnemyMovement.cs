using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private StatsScriptable enemyStats;
    [SerializeField] private Vector3[] patrollingPoints;

    private IMoveAnim movementAnimation;
    private DetectingPlayer detectingDistanceToPlayer;
    private SpriteRenderer sprite;

    private float distanceToPlayer = 200f;
    private int positionPatrolNumber;
    public bool canMove;

    private void Start()
    {
        canMove = true;
        movementAnimation = GetComponent<IMoveAnim>();
        detectingDistanceToPlayer = GetComponent<DetectingPlayer>();
        sprite = GetComponent<SpriteRenderer>();
        detectingDistanceToPlayer.DetectedPlayerEvent += StartMoving;
        detectingDistanceToPlayer.DetectedNotPlayerEvent += ResetDistance;
        StartCoroutine(PatrollingArea());
    }

    private IEnumerator PatrollingArea()
    {
        movementAnimation.GetMovementAnimation();
        while (distanceToPlayer >= enemyStats.DetectionRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrollingPoints[positionPatrolNumber], enemyStats.MovementSpeed * Time.deltaTime);
            if(transform.position == patrollingPoints[positionPatrolNumber])
            {
                if (positionPatrolNumber == patrollingPoints.Length - 1)
                    positionPatrolNumber = 0;
                else
                    positionPatrolNumber++;
            }
            yield return null;
        }
    }

    private IEnumerator MoveTowardsPlayer()
    {
        if(player.activeSelf && canMove)
            movementAnimation.GetMovementAnimation();
        else
            movementAnimation.StopMovementAnimation();
        while (distanceToPlayer >= enemyStats.AttackRange && distanceToPlayer <= enemyStats.DetectionRange && canMove)
        {
            Vector2 destination = Vector2.MoveTowards(transform.position, player.transform.position, enemyStats.MovementSpeed * Time.deltaTime);
            destination.y = transform.position.y;
            transform.position = destination;
            MovingDirection(player);
            yield return null;
        }
    }

    private void MovingDirection(GameObject player)
    {
        if (player.transform.position.x - transform.position.x < 0)
            sprite.flipX = true;
        else if(player.transform.position.x - transform.position.x > 0)
            sprite.flipX = false;
    }

    private void StartMoving()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        StopCoroutine(PatrollingArea());
        StartCoroutine(MoveTowardsPlayer());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            StopAllCoroutines();
            movementAnimation.StopMovementAnimation();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    { 
        if (collision.gameObject.layer == 3)
        {
            Invoke(nameof(WaitAfterMoving), 0.15f);
        }
    }

    private void WaitAfterMoving()
    {
        if (gameObject.activeSelf)
            StartCoroutine(MoveTowardsPlayer());
    }

    private void ResetDistance()
    {
        movementAnimation.StopMovementAnimation();
        distanceToPlayer = 200f;
        StopCoroutine(MoveTowardsPlayer());
    }

    private void OnDisable()
    {
        StopCoroutine(MoveTowardsPlayer());
        detectingDistanceToPlayer.DetectedPlayerEvent -= StartMoving;
        detectingDistanceToPlayer.DetectedNotPlayerEvent -= ResetDistance;
    }
}
