using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScythe : MonoBehaviour
{
    [SerializeField] private int skillDamage;
    [SerializeField] private float skillAttackCooldown;
    [SerializeField] private GameObject scytheIcon;
    private PlayerControlActions playerAction;
    private ISkillAnimator skillAnimator;
    private bool canUseScythe = true;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        playerAction = new PlayerControlActions();
        skillAnimator = GetComponentInParent<ISkillAnimator>();
    }

    private void SkillAttack(InputAction.CallbackContext skill)
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame && canUseScythe)
        {
            scytheIcon.SetActive(false);
            canUseScythe = false;
            skillAnimator.SkillAttackAnimation(1);
            rb.AddForce(Vector2.up * 40, ForceMode2D.Force);
            StartCoroutine(ScytheCooldown());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetType() == typeof(CapsuleCollider2D) && collision.gameObject.layer == 7)
            collision.GetComponent<ITakeDamage>().TakeDamage(skillDamage);
    }

    IEnumerator ScytheCooldown()
    {
        yield return new WaitForSeconds(skillAttackCooldown);
        scytheIcon.SetActive(true);
        canUseScythe = true;
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
}
