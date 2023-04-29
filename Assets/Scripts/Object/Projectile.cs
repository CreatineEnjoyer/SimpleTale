using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private StatsScriptable stats;

    private int strength;
    private Rigidbody2D rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        strength = stats.Strength;

        Vector3 destination = new();
        if (player != null)
            destination = player.transform.position - transform.position;

        rb.velocity = new Vector2(destination.x, destination.y).normalized * speed;

        float projectileRotation = Mathf.Atan2(destination.y, destination.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, projectileRotation - 180);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
            collision.gameObject.GetComponent<ITakeDamage>().TakeDamage(strength);   
        Destroy(gameObject);
    }
}
