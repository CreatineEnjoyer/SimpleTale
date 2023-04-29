using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDirection : MonoBehaviour, IDirection
{
    [SerializeField] private GameObject player;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInParent<SpriteRenderer>();
    }

    void IDirection.AttackDirection()
    {
        Vector3 flipPosition;
        flipPosition = transform.localPosition;

        if (Distance())
        {
            sprite.flipX = false;
            if (transform.localPosition.x < 0f)
                FlippingPosition(transform, flipPosition);
        }
        else if (!Distance())
        {
            sprite.flipX = true;
            if (transform.localPosition.x > 0f)
                FlippingPosition(transform, flipPosition);
        }
    }

    private bool Distance()
    {
        if (player.transform.position.x - transform.parent.position.x > 0f) return true;
        else return false;
    }

    private void FlippingPosition(Transform attackPoint, Vector3 flipPosition)
    {
        flipPosition.x *= -1;
        attackPoint.localPosition = flipPosition;
    }
}
