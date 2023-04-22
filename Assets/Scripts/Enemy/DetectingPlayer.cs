using System;
using System.Collections;
using UnityEngine;

public class DetectingPlayer : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameObject player;
    [SerializeField] private StatsScriptable enemyStats;
    
    private BoxCollider2D enemyDetectionCollider;
    public event Action DetectedPlayerEvent;
    public event Action DetectedNotPlayerEvent;

    private void Start()
    {
        enemyDetectionCollider = GetComponent<BoxCollider2D>();
        enemyDetectionCollider.size = new Vector2(enemyStats.DetectionRange, 4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            DetectedPlayerEvent?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            DetectedNotPlayerEvent?.Invoke();
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireCube(transform.position, new Vector2(enemyStats.DetectionRange, 4f));
    //}
}
