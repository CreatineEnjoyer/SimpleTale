using UnityEngine;

public class CharacterAttackAnim : MonoBehaviour, IAttackAnim
{
    [SerializeField] private Animator animator;

    void IAttackAnim.BasicAttackAnim()
    {
        animator.SetTrigger("Attacking");
    }
}
