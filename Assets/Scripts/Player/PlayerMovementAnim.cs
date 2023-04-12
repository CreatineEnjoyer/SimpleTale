using UnityEngine;

public class PlayerMovementAnim : MonoBehaviour, IMoveAnim
{
    [SerializeField] Animator animator;

    public void GetMovementAnimation()
    {
        animator.SetBool("Walking", true);
    }

    public void StopMovementAnimation()
    {
        animator.SetBool("Walking", false);
    }
}
