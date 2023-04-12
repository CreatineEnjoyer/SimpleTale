using UnityEngine;

public class PlayerAttackAnim : MonoBehaviour, IAttackAnim
{
    [SerializeField] private Animator animator;

    public void BasicAttackAnim()
    {
        animator.SetTrigger("Attacking");
    }
}
