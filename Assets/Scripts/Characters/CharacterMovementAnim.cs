using UnityEngine;

public class CharacterMovementAnim : MonoBehaviour, IMoveAnim
{
    [SerializeField] Animator animator;
    [SerializeField] private AudioSource walkAudio;

    void IMoveAnim.GetMovementAnimation()
    {
        if(animator.GetBool("Walking") != true)
        {
            animator.SetBool("Walking", true);
            if (walkAudio != null) walkAudio.Play();
        } 
    }

    void IMoveAnim.StopMovementAnimation()
    {
        animator.SetBool("Walking", false);
        if (walkAudio != null) walkAudio.Play();
    }
}
