using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBasicAttack : MonoBehaviour, IDirection
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float BasicAttackCooldown;
    [SerializeField] private LayerMask enemyLayer;
    
    [SerializeField] private int strength;
    [SerializeField] private float range;
    [SerializeField] private GameObject swordIcon;

    [SerializeField] private AudioSource hitAudio;

    public bool canAttack = true;
    private PlayerControlActions playerAction;
    private SpriteRenderer sprite;
    private IAttackAnim attackAnimation;
    private Rigidbody2D rb;
    private IDirection direction;


    private void Start()
    {
        attackAnimation = GetComponent<IAttackAnim>();
        direction = GetComponent<IDirection>();
    }

    private void Awake()
    {
        playerAction = new PlayerControlActions();
        sprite = this.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void IDirection.AttackDirection()
    {
        Vector3 flipPosition;
        flipPosition = attackPoint.localPosition;

        if (playerAction.Player.Attack.ReadValue<Vector2>().x > 0f)
        {
            sprite.flipX = false;
            if(attackPoint.localPosition.x < 0f)
                FlippingPosition(attackPoint, flipPosition);
        }
        else if (playerAction.Player.Attack.ReadValue<Vector2>().x < 0f)
        {
            sprite.flipX = true;
            if(attackPoint.localPosition.x > 0f)
                FlippingPosition(attackPoint, flipPosition);
        }
    }

    private void BasicAttack(InputAction.CallbackContext obj)
    {
        if (canAttack)
        {
            direction.AttackDirection();
            attackAnimation.BasicAttackAnim();
            swordIcon.SetActive(false);
            canAttack = false;
            StartCoroutine(AttackCooldown());

            Collider2D[] enemyInRange = Physics2D.OverlapCircleAll(attackPoint.position, range, enemyLayer);
            foreach(Collider2D enemy in enemyInRange)
            {
                if(enemy.GetType() == typeof(CapsuleCollider2D))
                {
                    enemy.gameObject.GetComponent<ITakeDamage>().TakeDamage(strength);

                    if(playerAction.Player.Attack.ReadValue<Vector2>().x > 0f)
                        rb.AddForce(Vector2.left * 20, ForceMode2D.Force);
                           
                    else if(playerAction.Player.Attack.ReadValue<Vector2>().x < 0f)
                        rb.AddForce(Vector2.right * 20, ForceMode2D.Force); 

                    hitAudio.Play();
                }
                    
            }
        }
    }

    private void FlippingPosition(Transform attackPoint, Vector3 flipPosition)
    {
        flipPosition.x *= -1;
        attackPoint.localPosition = flipPosition;
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(BasicAttackCooldown);
        swordIcon.SetActive(true);
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

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(attackPoint.position, range);
    //}
}
