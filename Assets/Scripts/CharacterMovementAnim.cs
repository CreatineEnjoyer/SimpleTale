using UnityEngine;

public class CharacterMovementAnim : MonoBehaviour, IMoveAnim
{
    [SerializeField] Animator animator;

    void IMoveAnim.GetMovementAnimation()
    {
        animator.SetBool("Walking", true);
    }

    void IMoveAnim.StopMovementAnimation()
    {
        animator.SetBool("Walking", false);
    }
}
