using UnityEngine;
using System.Collections; // コルーチンを使用するために必要
using UnityEngine.SceneManagement;

public class PlayerCollisionControl : MonoBehaviour
{
    private Timer gameTimer; // Timerスクリプトへの参照
    public GameStateController gameStateController; // GameStateControllerへの参照
    public float invincibilityDuration = 2.0f; // コライダー無効化の時間
    private bool isInvincible = false;
    private AnimManager animManager;
    private AudioController audioController;
    private GameObject timerCountUpGameObject;
    private GameObject bufObikeGameObject1;
    private GameObject bufObikeGameObject2;
    public ParticleSystem particleSystemItem1;
    public GameObject bonusObject;
    private GameManager gameManager; // GameManagerへの参照
    private PlayerKnockBack playerKnockBack;


    void Awake()
    {
        // GameManagerのインスタンスを取得
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    void Start()
    {
        gameTimer = FindObjectOfType<Timer>(); // Timerコンポーネントを取得して参照を設定
        //gameStateController.SetPlayingState();
        animManager = FindObjectOfType<AnimManager>();
        playerKnockBack = GetComponent<PlayerKnockBack>();
        audioController = FindObjectOfType<AudioController>();
        timerCountUpGameObject = GameObject.Find("Canvas/TimerCountUp");
        bufObikeGameObject1 = GameObject.Find("Canvas/BuffObike1");
        bufObikeGameObject2 = GameObject.Find("Canvas/BuffObike2");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager.CurrentState == GameManager.GameState.Playing)
        {
        if (collision.CompareTag("Enemy") && !isInvincible)
        {
            Vector2 knockBackDirection = (transform.position - collision.transform.position).normalized; // プレイヤーから敵への方向
            float knockBackForce = 5.0f; // ノックバックの力
            playerKnockBack.KnockBack(knockBackDirection, knockBackForce); // ノックバックの実行
            
            // 敵に触れた時の処理
            //StartCoroutine(DisableColliderTemporarily());
            if (gameTimer != null)
            {
                gameTimer.SubtractTime(gameTimer.timePenalty); // 敵に触れた時に時間ペナルティを適用
                audioController.PlayDamageSE();
            }

            if (animManager != null)
            {
                animManager.ActivatePlayerAnimatorTrigger("trcinderella");
                //Debug.Log("aiueo");
            }
            StartCoroutine(invincibilityRoutine());
        }
        else if (collision.CompareTag("Finish"))
        {
            // ゴール到達時の処理
            if (gameStateController != null)
            {
                gameStateController.SetGameClearState(); // ゲームクリア状態を設定
                audioController.PlayGameClearSE();
                //sEmanager.PlayGameClearSE();
            }
            // Debug.Log("Goal Reached!");
        }

        else if (collision.CompareTag("Item"))
        {
            //Debug.Log("時間延長アイテムにあたった");
            //Animator animObike = Bufobike6.GetComponent<Animator>();
            //animObike.Play("BufObike");
            Destroy(collision.gameObject);
            bonusObject.SetActive(false);
            Transform particleSystemTransform = collision.transform.Find("Particle System");

            if (particleSystemTransform != null)
            {
                ParticleSystem itemParticleSystem = particleSystemTransform.GetComponent<ParticleSystem>();
                
                if (itemParticleSystem != null)
                {
                    Destroy(itemParticleSystem.gameObject);
                }
                else
                {
                    Debug.LogError("Particle System not found in Item.");
                    }
            }
            else
            {
                Debug.LogError("Particle System GameObject not found in Item.");
            }

            if (gameTimer != null)
            {
                gameTimer.AddTime(gameTimer.timeBonus); //アイテム取得で時間ボーナスを適用
                audioController.PlayTimeBonusSE();
                // Itemに触れた際の処理
                Invoke("BonusObjectFalse", 2);
            }

            if (animManager != null && timerCountUpGameObject != null)
            {
                //animManager.ActivateParentAnimatorTrigger(collision.gameObject, "blPos");
                animManager.ActivateCountUpTrigger(timerCountUpGameObject);
            }
            
            if (animManager != null && bufObikeGameObject1 != null)
            {
                animManager.ActivateBufObikeTrigger1(bufObikeGameObject1);
            }
            //Invoke("BonusObjectFalse", 2);
        }

        else if (collision.CompareTag("Item2"))
        {
            //Debug.Log("時間延長アイテムにあたった");
            //Animator animObike = Bufobike6.GetComponent<Animator>();
            //animObike.Play("BufObike");
            Destroy(collision.gameObject);
            bonusObject.SetActive(false);
            Transform particleSystemTransform = collision.transform.Find("Particle System");

            if (particleSystemTransform != null)
            {
                ParticleSystem itemParticleSystem = particleSystemTransform.GetComponent<ParticleSystem>();
                
                if (itemParticleSystem != null)
                {
                    Destroy(itemParticleSystem.gameObject);
                }
                else
                {
                    Debug.LogError("Particle System not found in Item.");
                    }
            }
            else
            {
                Debug.LogError("Particle System GameObject not found in Item.");
            }

            if (gameTimer != null)
            {
                gameTimer.AddTime(gameTimer.timeBonus); //アイテム取得で時間ボーナスを適用
                audioController.PlayTimeBonusSE();
                // Itemに触れた際の処理
                Invoke("BonusObjectFalse", 2);
            }

            if (animManager != null && timerCountUpGameObject != null)
            {
                //animManager.ActivateParentAnimatorTrigger(collision.gameObject, "blPos");
                animManager.ActivateCountUpTrigger(timerCountUpGameObject);
            }
            
            if (animManager != null && bufObikeGameObject2 != null)
            {
                animManager.ActivateBufObikeTrigger2(bufObikeGameObject2);
            }
            //Invoke("BonusObjectFalse", 2);
        }


        else if(collision.CompareTag("GameOver"))
        {
            if(gameStateController != null)
            {
                gameStateController.SetGameOverState();
                audioController.PlayGameOverSE();
            }
        }
        else if(collision.CompareTag("AnimTrigger"))
        {
            Debug.Log("Animikuyo");
        }
        }
        // 他のタグに対する処理をここに追加
    }

    void BonusObjectFalse()
    {
        bonusObject.SetActive(true);
    }

    IEnumerator invincibilityRoutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    /*private IEnumerator DisableColliderTemporarily()
    {
        // コライダーを一時的に無効化する処理
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
            yield return new WaitForSeconds(disableDuration);
            collider.enabled = true;
        }
    }*/
}