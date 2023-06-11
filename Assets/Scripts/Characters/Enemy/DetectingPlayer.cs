using System;
using System.Collections;
using UnityEngine;

public class DetectingPlayer : MonoBehaviour
{
    [SerializeField] private StatsScriptable enemyStats;
    [SerializeField] private float verticalDetection = 4.5f;

    private BoxCollider2D enemyDetectionCollider;
    public event Action DetectedPlayerEvent;
    public event Action DetectedNotPlayerEvent;
    private bool once = true;

    private void Start()
    {
        enemyDetectionCollider = GetComponent<BoxCollider2D>();
        enemyDetectionCollider.size = new Vector2(enemyStats.DetectionRange, verticalDetection);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && once == true)
        {
            once = false;
            Invoke(nameof(Wait), 0.015f);
        }
    }
    private void Wait()
    {
        DetectedPlayerEvent?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && once == false)
        {
            DetectedNotPlayerEvent?.Invoke();
            once = true;
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireCube(transform.position, new Vector2(enemyStats.DetectionRange, 4f));
    //}
}
