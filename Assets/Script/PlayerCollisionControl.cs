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
    private SEmanager sEmanager;
    private GameObject timerCountUpGameObject;
    private GameObject bufObikeGameObject;
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
        sEmanager = FindObjectOfType<SEmanager>();
        timerCountUpGameObject = GameObject.Find("Canvas/TimerCountUp");
        bufObikeGameObject = GameObject.Find("Canvas/BufObike");

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
                sEmanager.PlayDamageSE();
            }

            if (animManager != null)
            {
                animManager.ActivatePlayerAnimatorTrigger("blcinderella");
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
                sEmanager.PlayGameClearSE();
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

            if (gameTimer != null)
            {
                gameTimer.AddTime(gameTimer.timeBonus); //アイテム取得で時間ボーナスを適用
                sEmanager.PlayTimeBonusSE();
                // Itemに触れた際の処理
                Invoke("BonusObjectFalse", 2);
            }

            if (animManager != null && timerCountUpGameObject != null)
            {
                //animManager.ActivateParentAnimatorTrigger(collision.gameObject, "blPos");
                animManager.ActivateCountUpTrigger(timerCountUpGameObject);
            }
            if (animManager != null && bufObikeGameObject != null)
            {
                animManager.ActivateBufObikeTrigger(bufObikeGameObject);
            }
            //Invoke("BonusObjectFalse", 2);
        }
        else if(collision.CompareTag("GameOver"))
        {
            if(gameStateController != null)
            {
                gameStateController.SetGameOverState();
                sEmanager.PlayGameOverSE();
            }
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