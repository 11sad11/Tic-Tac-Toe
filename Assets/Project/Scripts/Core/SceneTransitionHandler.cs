using System.Collections;
using UnityEngine;

public class SceneTransitionHandler : Singleton<SceneTransitionHandler>
{
    protected override bool _isPersistent => false;
    [SerializeField] private Animator[] animators = null;

    private void Start()
    {
        if (animators == null) return;
        foreach (var animator in animators)
            animator.SetTrigger("Open");
    }

    public IEnumerator CloseScene()
    {
        foreach (var animator in animators)
            animator.SetTrigger("Close");

        foreach (var animator in animators)
        {
            yield return new WaitUntil(() =>
                animator.GetCurrentAnimatorStateInfo(0).IsTag("Close") &&
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f);
        }
    }
}