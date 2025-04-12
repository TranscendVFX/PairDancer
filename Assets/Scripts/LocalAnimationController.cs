using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LocalAnimationController : MonoBehaviour
{
    [SerializeField] private string queue;

    public float idleTime = 0;

    private Animator animator;

    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        if (animator == null) return;
        PlaySequence(queue);
        
    }
    
    // animation queue A - L?
    public void PlayAnimationByCode(string code)
    {
        string animName = GlobalAnimationController.Instance.GetAnimationName(code);
        if (!string.IsNullOrEmpty(animName))
        {
            animator.Play(animName, -1, 0f); // force play
            Debug.Log($"Play: {animName} (ID {code})");
        }
        else
        {
            Debug.LogWarning($"Error not found {code}");
        }
    }

    public void PlaySequence(string sequence)
    {
        StartCoroutine(PlaySequenceCoroutine(sequence));
    }

private IEnumerator PlaySequenceCoroutine(string sequence)
{
    foreach (char c in sequence)
    {
        PlayAnimationByCode(c.ToString());

        yield return new WaitUntil(() =>
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f &&
            !animator.IsInTransition(0));

        yield return new WaitForSeconds(idleTime);
    }
}

}

