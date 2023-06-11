using UnityEngine;

public class PlayerSkillDirection : MonoBehaviour, IDirection
{
    [SerializeField] private Transform attackPoint;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInParent<SpriteRenderer>();
    }

    void IDirection.AttackDirection()
    {
        Vector3 flipPosition;
        flipPosition = attackPoint.localPosition;

        if (sprite.flipX == false)
        {
            if (attackPoint.localPosition.x < 0f)
            {
                flipPosition.x *= -1;
                attackPoint.localPosition = flipPosition;
            }
        }
        else if (sprite.flipX == true)
        {
            if (attackPoint.localPosition.x > 0f)
            {
                flipPosition.x *= -1;
                attackPoint.localPosition = flipPosition;
            }
        }
    }
}
