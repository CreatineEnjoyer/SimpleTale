using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private AttackScriptable playerAttackStats;
    
    private int strength;
    private float range;
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

    private void Attack(InputAction.CallbackContext obj)
    {
        if(playerAction.Player.Attack.ReadValue<Vector2>().x > 0f)
        {
            sprite.flipX = false;
            if(attackPoint.localPosition.x < 0f)
            {
                Vector3 newScale = attackPoint.localPosition;
                newScale.x *= -1;
                attackPoint.localPosition = newScale;
            }
        }
        else if(playerAction.Player.Attack.ReadValue<Vector2>().x < 0f)
        {
            sprite.flipX = true;
            if (attackPoint.localPosition.x > 0f)
            {
                Vector3 newScale = attackPoint.localPosition;
                newScale.x *= -1;
                attackPoint.localPosition = newScale;
            }
        }
        animator.SetTrigger("Attacking");

        Collider2D[] enemyInRange = Physics2D.OverlapCircleAll(attackPoint.position, range, enemyLayer);

        foreach(Collider2D enemy in enemyInRange)
        {
            enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(strength);
        }
    }

    private void OnEnable()
    {
        playerAction.Player.Enable();
        playerAction.Player.Attack.started += Attack;
    }

    private void OnDisable()
    {
        playerAction.Player.Attack.started -= Attack;
        playerAction.Player.Disable();
    }
}
