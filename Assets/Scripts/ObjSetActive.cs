using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjSetActive : MonoBehaviour
{
    public GameObject targetObject;
    public Animator targetAnimator;
    //public GameObject targetObject2;
    //public GameObject targetObject3;
    //public GameObject targetObject4;
    //public GameObject targetObject5;
    private bool hasCollided = false;
    public GameManager gameManager;

    private void Awake()
    {
      gameManager = FindObjectOfType<GameManager>();

      // 現在のシーン名を取得
      string currentSceneName = SceneManager.GetActiveScene().name;

      // 特定のシーンでのみAnimatorを取得する
      if (currentSceneName == "Stage3")
      {
        targetAnimator = targetObject.GetComponent<Animator>();
      }
      targetObject.SetActive(false);
    }

    void Update()
    {
        // ゲーム状態がプレイ中の場合にのみ入力を受け付ける
        if (gameManager.CurrentState != GameManager.GameState.Playing)
        {
            // targetAnimatorがnullでないことを確認
            if (targetAnimator != null)
            {
                targetAnimator.enabled = false;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ゲーム状態がプレイ中の場合にのみ入力を受け付ける
        if (gameManager.CurrentState == GameManager.GameState.Playing)
        {
            if (collision.CompareTag("Player") && !hasCollided)
            {
                targetObject.SetActive(true);
                // targetAnimatorがnullでないことを確認
                if (targetAnimator != null)
                {
                    targetAnimator.enabled = true;
                }
                hasCollided = true;
            }
        }
    }

    public void AnimStart()
    {
        // targetAnimatorとtargetObjectがnullでない、かつactiveSelfがtrueであることを確認
        if (gameManager.CurrentState == GameManager.GameState.Playing && targetObject != null && targetObject.activeSelf && targetAnimator != null)
        {
            targetAnimator.enabled = true;
            Debug.Log("Animation Started");
        }
    }

    /*
    private float GetAnimationLength(Animator animator)
    {
        float length = 0f;
   
        AnimatorClipInfo[] clips = animator.GetCurrentAnimatorClipInfo(0);

        if (clips.Length > 0)
        {
            length = clips[0].clip.length;
        }

        return length;
    }
    

    private void DeleteObject()
    {
        Destroy(targetObject);
    }
    */
}