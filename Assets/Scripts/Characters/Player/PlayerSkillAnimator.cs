using UnityEngine;

public class PlayerSkillAnimator : MonoBehaviour, ISkillAnimator
{
    [SerializeField] private Animator animator;

    void ISkillAnimator.SkillAttackAnimation(int skillNumber)
    {
        animator.SetInteger("SkillNumber", skillNumber);
    }

    void ISkillAnimator.ResetSkillAttackAnimation() 
    {
        animator.SetInteger("SkillNumber", 0);
    }
}
