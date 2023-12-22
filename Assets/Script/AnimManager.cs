using UnityEngine;
using System.Collections.Generic;

public class AnimManager : MonoBehaviour
{

    public GameManager gameManager;

    // 指定された子オブジェクトの親オブジェクトのAnimatorのTriggerをアクティブにする
    /*public void ActivateParentAnimatorTrigger(GameObject childObject, string triggerName)
    {
        Transform parentTransform = childObject.transform.parent;

        if (parentTransform != null)
        {
            Animator parentAnimator = parentTransform.GetComponent<Animator>();
    
            if (parentAnimator != null)
            {
                parentAnimator.SetTrigger(triggerName);

                ParticleSystem childParticleSystem = childObject.GetComponentInChildren<ParticleSystem>();
                if (childParticleSystem != null)
                {
                    Destroy(childParticleSystem.gameObject);
                }
            }
        }
    }*/
    
    private GameObject targetObject1;
    private GameObject targetObject2;
    private GameObject targetObject3;
    private List<GameObject> targetObject4List;
    private List<GameObject> targetObject5List;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        // オブジェクトの検索とリストの初期化
        targetObject1 = GameObject.Find("針_短針");
        targetObject2 = GameObject.Find("針_長針");
        targetObject3 = GameObject.Find("Player");
        targetObject4List = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        targetObject5List = new List<GameObject>(GameObject.FindGameObjectsWithTag("chandelier"));
    }

    void Update()
    {
           
        /*if (gameManager.CurrentState == GameManager.GameState.Pause)
        {
            StopAnimation(targetObject1);
            StopAnimation(targetObject2);
            StopAnimation(targetObject3);
            foreach (GameObject enemys in targetObject4List)
            {
                StopAnimation(enemys);
            }
            foreach (GameObject chandeliers in targetObject5List)
            {
                StopAnimation(chandeliers);
            }
        }
        else if (gameManager.CurrentState == GameManager.GameState.Playing)
        {
            StartAnimation(targetObject1);
            StartAnimation(targetObject2);
            StartAnimation(targetObject3);
            foreach (GameObject enemys in targetObject4List)
            {
                StartAnimation(enemys);
            }
            foreach (GameObject chandeliers in targetObject5List)
            {
                StartAnimation(chandeliers);
            }
        }*/

        /*if (gameManager.CurrentState == GameManager.GameState.Playing)
        {
            foreach (GameObject enemys in targetObject4List)
            {
                ActivatekyakuTrigger(enemys);
            }
            Debug.Log("ifnonaka");
        }*/

        if (gameManager.CurrentState == GameManager.GameState.Playing)
        {
            StartAnimation(targetObject1);
            StartAnimation(targetObject2);
            StartAnimation(targetObject3);
            foreach (GameObject enemys in targetObject4List)
            {
                StartAnimation(enemys);
            }
            foreach (GameObject chandeliers in targetObject5List)
            {
                StartAnimation(chandeliers);
            }
        }
        else
        {
           
            StopAnimation(targetObject1);
            StopAnimation(targetObject2);
            StopAnimation(targetObject3);
            foreach (GameObject enemys in targetObject4List)
            {
                StopAnimation(enemys);
            }
            foreach (GameObject chandeliers in targetObject5List)
            {
                StopAnimation(chandeliers);
            }
        }
    }

    //
    public void ActivatekyakuTrigger(GameObject enemys)
    {
        Animator enemysAnimator = enemys.GetComponent<Animator>();
        
        if (enemysAnimator != null)
        {
            enemysAnimator.SetTrigger("goanim");
        }
    }

    // バフオビケアニメーションをアクティブにする
    public void ActivateBufObikeTrigger(GameObject bufObikeGameObject)
    {
        Animator bufObikeAnimator = bufObikeGameObject.GetComponent<Animator>();

        if(bufObikeAnimator != null)
        {
            bufObikeAnimator.SetTrigger("blobi");
        }

        ParticleSystem BuffParticleSystem = GameObject.Find("Buff/obike_wizard/Particle System").GetComponentInChildren<ParticleSystem>();
                if (BuffParticleSystem != null)
                {
                    Destroy(BuffParticleSystem.gameObject);
                }
    }

    // タイマーのカウントアップアニメーションをアクティブにする
    public void ActivateCountUpTrigger(GameObject timerCountUpGameObject)
    {
        Animator timerCountUpAnimator = timerCountUpGameObject.GetComponent<Animator>();

        if(timerCountUpAnimator != null)
        {
            timerCountUpAnimator.SetTrigger("blTim");
        }
    }
    
    // 指定されたオブジェクトのアニメーションを停止する
    public void StopAnimation(GameObject targetObject)
    {
        Animator targetAnimator = targetObject.GetComponent<Animator>();
        if(targetAnimator != null)
        {
            targetAnimator.enabled = false;
        }
    }
    public void StartAnimation(GameObject targetObject)
    {
        Animator targetAnimator = targetObject.GetComponent<Animator>();
        if(targetAnimator != null)
        {
            targetAnimator.enabled = true;
        }
    }

    // プレイヤーオブジェクトの特定のアニメーショントリガーをアクティブにする
    public void ActivatePlayerAnimatorTrigger(string blcinderella)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Animator animator = player.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger(blcinderella);
            }
        }
    }
}
