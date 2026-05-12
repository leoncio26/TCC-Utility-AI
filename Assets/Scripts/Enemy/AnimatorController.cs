using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    //[SerializeField]
    //private string meleeTrigger;

    public void Play(string animName)
    {
    //    RuntimeAnimatorController controller =
    //animator.runtimeAnimatorController;

    //    foreach (AnimationClip clip in controller.animationClips)
    //    {
    //        Debug.Log(clip.name);
    //    }

        animator.Play(animName);
    }
}
