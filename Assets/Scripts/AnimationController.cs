using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private GameManager gameManager;

    // アニメーションを制御するためのターゲットオブジェクトの参照
    public GameObject[] animatedObjects;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        // ゲーム状態に応じてアニメーションを制御
        if (gameManager.CurrentState == GameManager.GameState.Playing)
        {
            SetAnimationsActive(true);
        }
        else
        {
            SetAnimationsActive(false);
        }
    }

    private void SetAnimationsActive(bool isActive)
    {
        foreach (var obj in animatedObjects)
        {
            Animator animator = obj.GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = isActive;
            }
        }
    }

    // 他のスクリプトから特定のアニメーションをトリガーするためのメソッド
    public void TriggerAnimation(GameObject targetObject, string triggerName)
    {
        Animator animator = targetObject.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }
    }
}
