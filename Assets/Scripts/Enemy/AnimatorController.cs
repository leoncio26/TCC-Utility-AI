using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string meleeTrigger;

    public void PlayAttackMelee()
    {
    //    RuntimeAnimatorController controller =
    //animator.runtimeAnimatorController;

    //    foreach (AnimationClip clip in controller.animationClips)
    //    {
    //        Debug.Log(clip.name);
    //    }

        animator.Play(meleeTrigger);
    }
}
