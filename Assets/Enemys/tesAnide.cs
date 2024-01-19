using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedAnimationStart : MonoBehaviour
{
    public float delayInSeconds = 2f;  // アニメーションを開始するまでの遅延時間（秒）
    private Animator animator;
    private bool animationStarted = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on the object.");
        }
    }

    void Update()
    {
        if (!animationStarted && Time.time >= delayInSeconds)
        {
            StartAnimation();
        }
    }

    void StartAnimation()
    {
        if (animator != null)
        {
            animator.enabled = true;
            
            animationStarted = true;
        }
    }
}