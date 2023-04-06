using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBasicAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float BasicAttackCooldown;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private AttackScriptable playerAttackStats;
    
    private int strength;
    private float range;
    private bool canAttack = true;
    private PlayerControlActions playerAction;
    private SpriteRenderer sprite;
    

    private void Start()
    {
        strength = playerAttackStats.Strength;
        range = playerAttackStats.Range;
    }
    private void Awake()
    {
        playerAction = new PlayerControlActions();
        sprite = this.GetComponent<SpriteRenderer>();
    }

    private void AttackDirection()
    {
        Vector3 flipPosition;

        if (playerAction.Player.Attack.ReadValue<Vector2>().x > 0f)
        {
            sprite.flipX = false;
            if (attackPoint.localPosition.x < 0f)
            {
                flipPosition = attackPoint.localPosition;
                flipPosition.x *= -1;
                attackPoint.localPosition = flipPosition;
            }
        }
        else if (playerAction.Player.Attack.ReadValue<Vector2>().x < 0f)
        {
            sprite.flipX = true;
            if (attackPoint.localPosition.x > 0f)
            {
                flipPosition = attackPoint.localPosition;
                flipPosition.x *= -1;
                attackPoint.localPosition = flipPosition;
            }
        }
    }

    private void BasicAttack(InputAction.CallbackContext obj)
    {
        AttackDirection();

        if (canAttack)
        {
            animator.SetTrigger("Attacking");

            canAttack = false;
            StartCoroutine(AttackCooldown());

            Collider2D[] enemyInRange = Physics2D.OverlapCircleAll(attackPoint.position, range, enemyLayer);
            foreach(Collider2D enemy in enemyInRange)
            {
                enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(strength);
            }
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(BasicAttackCooldown);
        canAttack = true;
    }

    private void OnEnable()
    {
        playerAction.Player.Enable();
        playerAction.Player.Attack.started += BasicAttack;
    }

    private void OnDisable()
    {
        playerAction.Player.Attack.started -= BasicAttack;
        playerAction.Player.Disable();
    }
}
