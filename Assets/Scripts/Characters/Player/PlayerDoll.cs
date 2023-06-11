using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDoll : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float skillAttackCooldown;
    [SerializeField] private int throwingPower;
    [SerializeField] private GameObject dollIcon;

    private PlayerControlActions playerAction;
    private ISkillAnimator skillAnimator;
    private IDirection direction;
    private bool canUseDoll = false;

    private void Awake()
    {
        dollIcon.SetActive(false);
        WeaponPickup.WeaponPickupEvent += WeaponActivated;
        playerAction = new PlayerControlActions();
        skillAnimator = GetComponentInParent<ISkillAnimator>();
        direction = GetComponent<IDirection>();
    }

    private void SkillAttack(InputAction.CallbackContext skill)
    {
        if (Keyboard.current.digit3Key.wasPressedThisFrame && canUseDoll)
        {
            direction.AttackDirection();
            dollIcon.SetActive(false);
            canUseDoll = false;
            skillAnimator.SkillAttackAnimation(3);
            var dollObject = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            if (transform.localPosition.x > 0f)
                dollObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(throwingPower, 0), ForceMode2D.Force);
            else if(transform.localPosition.x < 0f)
                dollObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-throwingPower, 0), ForceMode2D.Force);
            StartCoroutine(DollCooldown());
        }
    }

    IEnumerator DollCooldown()
    {
        yield return new WaitForSeconds(skillAttackCooldown);
        dollIcon.SetActive(true);
        canUseDoll = true;
    }

    private void WeaponActivated(WeaponPickup weapon)
    {
        if (weapon.name == "NonThrowableDoll(Clone)")
        {
            dollIcon.SetActive(true);
            canUseDoll = true;
        }
    }

    private void OnEnable()
    {
        playerAction.Player.Enable();
        playerAction.Player.Skills.started += SkillAttack;
    }

    private void OnDisable()
    {
        WeaponPickup.WeaponPickupEvent -= WeaponActivated;
        playerAction.Player.Skills.started -= SkillAttack;
        playerAction.Player.Disable();
    }
}
