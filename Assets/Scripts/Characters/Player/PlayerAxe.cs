using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAxe : MonoBehaviour
{
    [SerializeField] private int skillDamage;
    [SerializeField] private float skillAttackCooldown;
    [SerializeField] private Transform attackPoint;
    private PlayerControlActions playerAction;
    private ISkillAnimator skillAnimator;
    private bool canUseAxe = true;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = this.GetComponentInParent<SpriteRenderer>();
        playerAction = new PlayerControlActions();
        skillAnimator = GetComponentInParent<ISkillAnimator>();
    }
    private void AttackDirection()
    {
        Vector3 flipPosition;
        flipPosition = attackPoint.localPosition;

        if (sprite.flipX == false)
        {
            if (attackPoint.localPosition.x < 0f)
                FlippingPosition(attackPoint, flipPosition);
        }
        else if (sprite.flipX == true)
        {
            if (attackPoint.localPosition.x > 0f)
                FlippingPosition(attackPoint, flipPosition);
        }
    }

    private void FlippingPosition(Transform attackPoint, Vector3 flipPosition)
    {
        flipPosition.x *= -1;
        attackPoint.localPosition = flipPosition;
    }

    private void SkillAttack(InputAction.CallbackContext skill)
    {      
        if (Keyboard.current.digit2Key.wasPressedThisFrame && canUseAxe)
        {
            AttackDirection();
            canUseAxe = false;
            skillAnimator.SkillAttackAnimation(2);
            StartCoroutine(AxeCooldown());
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetType() == typeof(CapsuleCollider2D) && collision.gameObject.layer == 7)
            collision.GetComponent<ITakeDamage>().TakeDamage(skillDamage);
    }

    IEnumerator AxeCooldown()
    {
        yield return new WaitForSeconds(skillAttackCooldown);
        canUseAxe = true;
    }

    private void OnEnable()
    {
        playerAction.Player.Enable();
        playerAction.Player.Skills.started += SkillAttack;
    }

    private void OnDisable()
    {
        playerAction.Player.Skills.started -= SkillAttack;
        playerAction.Player.Disable();
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireCube(transform.position, new Vector3(0.6019654f, 2.4026f));
    //}
}
    