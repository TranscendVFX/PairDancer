using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorChecker : MonoBehaviour
{
    [SerializeField] private Animator animator1;
    [SerializeField] private Animator animator2;
    [SerializeField] private Animator animator3;
    private float timer;
    void Start()
    {
        
    }

    void Update()
    {
        // timer += Time.deltaTime;
        // if (timer >= 1.0f)
        // {
        //     timer = 0f;
        //     CheckAnimation(animator1);
        //     CheckAnimation(animator2);
        //     CheckAnimation(animator3);

        // }
    }

    private static void CheckAnimation(Animator animator)
    {
        if (animator != null)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            string clipName = stateInfo.IsName("") ? "Idle/Empty" : stateInfo.shortNameHash.ToString();

            foreach (var clip in animator.runtimeAnimatorController.animationClips)
            {
                if (clip.name.GetHashCode() == stateInfo.shortNameHash)
                {
                    clipName = clip.name;
                    break;
                }
            }

            Debug.Log($"CurrentAvatar {animator.transform.parent.name} {clipName} ");
        }
    }
}
