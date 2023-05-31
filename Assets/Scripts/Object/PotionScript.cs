using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    [SerializeField]
    private float minLaunchForce = 3f;
    [SerializeField]
    private float maxLaunchForce = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 launchCoinDirection = Random.insideUnitCircle.normalized;
        float launchPotionSpeed = Random.Range(minLaunchForce, maxLaunchForce);
        rb.velocity = launchCoinDirection * launchPotionSpeed;
    }
}
